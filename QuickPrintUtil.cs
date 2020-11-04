using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.EditorInput;
using Autodesk.AutoCAD.Geometry;
using Autodesk.AutoCAD.PlottingServices;
using Autodesk.AutoCAD.Publishing;
using Autodesk.AutoCAD.Runtime;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickPrint
{
    public class QuickPrintUtil
    {
        private static QuickPrintUI menu = null;

        [CommandMethod("qp")]
        public static void QuickPrint()
        {
            if (menu == null)
            {
                menu = new QuickPrintUI();
            }

            Application.ShowModelessDialog(menu);
        }

        [CommandMethod("QuickView")]
        public static void QuickView()
        {
            List<Point2d> viewsLower = new List<Point2d>() { new Point2d(0, 0.5), new Point2d(0, 0), new Point2d(0.5, 0) };
            List<Point2d> viewsUpper = new List<Point2d>() { new Point2d(0.5, 1), new Point2d(0.5, 0.5), new Point2d(1, 0.5) };
            List<OrthographicView> viewsDirection = new List<OrthographicView>() { OrthographicView.TopView, OrthographicView.FrontView, OrthographicView.RightView,  };

            Document doc = Application.DocumentManager.MdiActiveDocument;
            Database db = doc.Database;

            Editor ed = doc.Editor;

            Autodesk.AutoCAD.ApplicationServices.Application.MainWindow.Focus();

            LayoutManager layoutManager = LayoutManager.Current;

            if (layoutManager.LayoutExists("QuickView"))
            {
                layoutManager.CurrentLayout = "QuickView";
                return;
            }

            using (DocumentLock lockDoc = doc.LockDocument())
            {
                using (Transaction trans = db.TransactionManager.StartTransaction())
                {
                    ViewportTable vportTable = trans.GetObject(db.ViewportTableId, OpenMode.ForWrite) as ViewportTable;
                    ViewportTableRecord vportTableRec = trans.GetObject(ed.ActiveViewportId, OpenMode.ForWrite) as ViewportTableRecord;

                    BlockTable bTable = trans.GetObject(db.BlockTableId, OpenMode.ForRead) as BlockTable;
                    BlockTableRecord bTableRec = trans.GetObject(bTable[BlockTableRecord.PaperSpace], OpenMode.ForWrite) as BlockTableRecord;

                    vportTableRec.LowerLeftCorner = new Point2d(0.5, 0.5);
                    vportTableRec.UpperRightCorner = new Point2d(1, 1);

                    vportTableRec.ViewDirection = new Vector3d(Math.Sqrt(1.0 / 3.0), -Math.Sqrt(1.0 / 3.0), Math.Sqrt(1.0 / 3.0));

                    for (int i = 0; i < 3; i++)
                    {
                        using (ViewportTableRecord vportTableRecNew = new ViewportTableRecord())
                        {
                            vportTable.Add(vportTableRecNew);

                            trans.AddNewlyCreatedDBObject(vportTableRecNew, true);

                            vportTableRecNew.SetViewDirection(viewsDirection[i]);

                            vportTableRecNew.Name = "*Active";

                            vportTableRecNew.LowerLeftCorner = viewsLower[i];
                            vportTableRecNew.UpperRightCorner = viewsUpper[i];
                        }
                    }

                    ed.UpdateTiledViewportsFromDatabase();

                    foreach (ObjectId vp in vportTable)
                    {
                        ViewportTableRecord vpTR = trans.GetObject(vp, OpenMode.ForRead) as ViewportTableRecord;


                        if (vpTR.Name == "*Active")
                        {
                            Application.SetSystemVariable("CVPORT", vpTR.Number);

                            ed.Command("_.zoom", "_extents");

                            using (ViewTableRecord vTableRec = ed.GetCurrentView())
                            {
                                Point3d pCenter = new Point3d(vTableRec.CenterPoint.X, vTableRec.CenterPoint.Y, 0);

                                ed.Command("_.zoom", "_scale", "0.7x");
                            }
                        }
                    }

                    ObjectId layoutID = layoutManager.CreateLayout("QuickView");

                    Layout layout = trans.GetObject(layoutID, OpenMode.ForRead) as Layout;

                    if (layout.TabSelected == false)
                    {
                        layoutManager.CurrentLayout = layout.LayoutName;
                    }

                    BlockTableRecord blckTableRec = trans.GetObject(layout.BlockTableRecordId, OpenMode.ForWrite) as BlockTableRecord;

                    int count = 0;

                    foreach (ObjectId id in blckTableRec)
                    {
                        Viewport vp = trans.GetObject(id, OpenMode.ForRead) as Viewport;

                        if (vp != null && count != 0)
                        {
                            vp.UpgradeOpen();
                            vp.Height = layout.PlotPaperSize.X * 0.4;
                            vp.Width = layout.PlotPaperSize.Y * 0.4;

                            vp.CenterPoint = new Point3d(layout.PlotPaperSize.Y * 0.75, layout.PlotPaperSize.X * 0.75, 0); vp.SetViewDirection(OrthographicView.NonOrthoView);

                            vp.ViewDirection = new Vector3d(Math.Sqrt(1.0 / 3.0), -Math.Sqrt(1.0 / 3.0), Math.Sqrt(1.0 / 3.0));
                            vp.GridOn = false;

                            ed.SwitchToModelSpace();
                            ed.Command("_.zoom", "_scale", "0.7x");
                            ed.SwitchToPaperSpace();
                        }

                        count++;
                    }

                    List<Point3d> centerPoints = new List<Point3d>() { new Point3d(layout.PlotPaperSize.Y * 0.25, layout.PlotPaperSize.X * 0.75, 0), new Point3d(layout.PlotPaperSize.Y * 0.25, layout.PlotPaperSize.X * 0.25, 0), new Point3d(layout.PlotPaperSize.Y * 0.75, layout.PlotPaperSize.X * 0.25, 0) };

                    for (int i = 0; i < 3; i++)
                    {
                        using (Viewport vp = new Viewport())
                        {
                            ed.SwitchToPaperSpace();

                            blckTableRec.AppendEntity(vp);
                            trans.AddNewlyCreatedDBObject(vp, true);

                            vp.CenterPoint = centerPoints[i];

                            vp.Height = layout.PlotPaperSize.X * 0.4;
                            vp.Width = layout.PlotPaperSize.Y * 0.4;

                            vp.SetViewDirection(viewsDirection[i]);

                            vp.On = true;

                            ed.SwitchToModelSpace();

                            ed.Command("_.zoom", "_extents");

                            ed.Command("_.zoom", "_scale", "0.7x");
                        }
                    }

                    ed.SwitchToPaperSpace();

                    trans.Commit();
                }
            }
        }

        [CommandMethod("SetColor", CommandFlags.UsePickSet)]
        public static void SetColor()
        {
            Document doc = Application.DocumentManager.MdiActiveDocument;
            Database db = doc.Database;

            Editor ed = doc.Editor;

            Autodesk.AutoCAD.ApplicationServices.Application.MainWindow.Focus();

            using (Transaction trans = db.TransactionManager.StartTransaction())
            {
                PromptSelectionResult selectionPrompt;
                SelectionSet selectionSet;

                if (ed.SelectImplied().Status == PromptStatus.OK)
                {
                    selectionSet = ed.SelectImplied().Value;

                    foreach (SelectedObject obj in selectionSet)
                    {
                        if (obj != null)
                        {
                            Entity ent = trans.GetObject(obj.ObjectId, OpenMode.ForWrite) as Entity;

                            if (ent != null)
                            {
                                ent.Color = Autodesk.AutoCAD.Colors.Color.FromColor(menu._colorBox.BackColor);
                            }
                        }
                    }
                }                
                else
                {
                    selectionPrompt = ed.GetSelection();

                    if (selectionPrompt.Status == PromptStatus.OK)
                    {
                        selectionSet = selectionPrompt.Value;

                        foreach (SelectedObject obj in selectionSet)
                        {
                            if (obj != null)
                            {
                                Entity ent = trans.GetObject(obj.ObjectId, OpenMode.ForWrite) as Entity;

                                if (ent != null)
                                {
                                    ent.Color = Autodesk.AutoCAD.Colors.Color.FromColor(menu._colorBox.BackColor);
                                }
                            }
                        }
                    }
                }

                trans.Commit();
            }
        }

        [CommandMethod("AnnoDimLinear")]
        public static void DimLinear()
        {
            Document doc = Application.DocumentManager.MdiActiveDocument;

            Editor ed = doc.Editor;

            Autodesk.AutoCAD.ApplicationServices.Application.MainWindow.Focus();

            ed.Command("_.dimlinear");
        }

        [CommandMethod("AnnoDimAligned")]
        public static void DimAligned()
        {
            Document doc = Application.DocumentManager.MdiActiveDocument;

            Editor ed = doc.Editor;

            Autodesk.AutoCAD.ApplicationServices.Application.MainWindow.Focus();

            ed.Command("_.dimaligned");
        }

        [CommandMethod("AnnoDimAngular")]
        public static void DimAngular()
        {
            Document doc = Application.DocumentManager.MdiActiveDocument;

            Editor ed = doc.Editor;

            Autodesk.AutoCAD.ApplicationServices.Application.MainWindow.Focus();

            ed.Command("_.dimangular");
        }

        [CommandMethod("AnnoDimRadius")]
        public static void DimRadius()
        {
            Document doc = Application.DocumentManager.MdiActiveDocument;

            Editor ed = doc.Editor;

            Autodesk.AutoCAD.ApplicationServices.Application.MainWindow.Focus();

            ed.Command("_.dimradius");
        }

        [CommandMethod("AnnoDimDiameter")]
        public static void DimDiameter()
        {
            Document doc = Application.DocumentManager.MdiActiveDocument;

            Editor ed = doc.Editor;

            Autodesk.AutoCAD.ApplicationServices.Application.MainWindow.Focus();

            ed.Command("_.dimdiameter");
        }

        [CommandMethod("AnnoDimArc")]
        public static void DimArc()
        {
            Document doc = Application.DocumentManager.MdiActiveDocument;

            Editor ed = doc.Editor;

            Autodesk.AutoCAD.ApplicationServices.Application.MainWindow.Focus();

            ed.Command("_.dimarc");
        }

        [CommandMethod("PrintToPdf")]
        public static void PrintToPdf()
        {
            Document doc = Application.DocumentManager.MdiActiveDocument;

            Editor ed = doc.Editor;

            Autodesk.AutoCAD.ApplicationServices.Application.MainWindow.Focus();

            object obj = Application.GetSystemVariable("DWGTITLED");

            string drawingName = Path.GetFileName(doc.Name);
            string drawingPath = doc.Name;

            if (System.Convert.ToInt16(obj) == 0)
            {
                drawingPath = "d:\\QuickPrint.dwg";
                drawingName = "QuickPrint.dwg";
            }

            doc.Database.SaveAs(drawingPath, true, DwgVersion.Current, doc.Database.SecurityParameters);

            DsdData dsd = new DsdData();
            

            DSDObject dsdObj = new DSDObject();
            dsdObj.DWG = drawingPath;
            dsdObj.DwgName = drawingName;
            dsdObj.Layout = "QuickView";

            using (StreamWriter writer = new StreamWriter("d:\\QuickPrint.dsd"))
            {
                writer.WriteLine("[DWF6Version]");
                writer.WriteLine("Ver=1");
                writer.WriteLine(dsdObj.CreateDSDEntry());
                writer.WriteLine("[Target]");
                writer.WriteLine("Type=6");
                writer.WriteLine("DWF=d:\\QuickPrint.pdf");
                writer.WriteLine("OUT=d:\\");
                writer.WriteLine("PWD=");
            }

            FileInfo fi = new FileInfo("D:\\QuickPrint.dsd");
            if (fi.Length > 0)
            {
                //ed.WriteMessage($"{fi.FullName}\n");
                Application.SetSystemVariable("FILEDIA", 0);
                doc.SendStringToExecute($"-publish {fi.FullName}\n", true, false, false);
                //Application.Publisher.AboutToEndPublishing += new AboutToEndPublishingEventHandler(Publisher_AboutToEndPublishing);
                Application.Publisher.AboutToBeginBackgroundPublishing += Publisher_AboutToBeginBackgroundPublishing;
            }
        }

        private static void Publisher_AboutToBeginBackgroundPublishing(object sender, AboutToBeginBackgroundPublishingEventArgs e)
        {
            Application.DocumentManager.MdiActiveDocument.Editor.WriteMessage("About to begin publishing\n");
            Application.SetSystemVariable("FILEDIA", 1);
        }
    }
}
