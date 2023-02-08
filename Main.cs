using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.DB.Mechanical;
using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_8_1
{
    [Transaction(TransactionMode.Manual)]
    public class Main : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            UIApplication uiapp = commandData.Application;
            UIDocument uidoc = uiapp.ActiveUIDocument;
            Document doc = uidoc.Document;

            string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string name = "IFCExport.ifc";
            IFCExportOptions ifcOptions = new IFCExportOptions();
            using (var ts = new Transaction(doc, "IFC export"))
            {
                ts.Start();

                if (doc.Export(path, name, ifcOptions))
                {
                    TaskDialog.Show("Информация", "Успешно экспортировано");
                }
                else { TaskDialog.Show("Информация", "Ошибка"); }

                ts.Commit();
            }
            return Result.Succeeded;

        }
    }
}
