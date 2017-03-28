using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Eplan.EplApi.ApplicationFramework;
using System.Windows.Forms;
using Eplan.EplApi.HEServices;
using Eplan.EplApi.DataModel;
using System.Collections;
using Eplan.EplApi.Base;
using Eplan.EplApi.DataModel.MasterData;

namespace Eplan.EplAddin.Test
{
    class ActionCheckout : IEplAction
    {
        public bool Execute(ActionCallingContext oActionCallingContext)
        {
            // MessageBox.Show("Checkout Action");

            SelectionSet selectionSet = new SelectionSet();
            Project project = selectionSet.GetCurrentProject(true);

            //string creator = project.Properties[10013];
            //MessageBox.Show(creator);

            //Location[] location = project.GetLocationObjects(Project.Hierarchy.Plant);
            //string strDesc1 = ISOCodeUtil.GetISOStringValue(location[0].Properties.LOCATION_DESCRIPTION_SUPPLEMENTARYFIELD[1]);

            //MessageBox.Show(strDesc1);

            Page[] pages = project.Pages;

            DMObjectsFinder finder = new DMObjectsFinder(project);
            PagePropertyList ppl = new PagePropertyList();
            // ppl.DESIGNATION_LOCATION = "C1";
            // ppl.DESIGNATION_DOCTYPE = "SINGLE";
            // ppl.DESIGNATION_DOCTYPE = "MULTI";
            ppl.PAGE_TYPE_NUMERIC = 1;

            PagesFilter pf = new PagesFilter();
            pf.SetFilteredPropertyList(ppl);

            Page[] sPages = finder.GetPages(pf);

            // sPages[0].
            //FunctionPropertyList fpl = new FunctionPropertyList();

            //FunctionsFilter ff = new FunctionsFilter();
            //ff.SetFilteredPropertyList()

            ArrayList list = new ArrayList();

            Function[] ffss = finder.GetFunctions(null);

            foreach (Function f in ffss)
            {
                if (f.Category == Function.Enums.Category.Motor)
                {
                    list.Add(f);
                    ArticleReference[] ars = f.ArticleReferences;

                    if (ars.Count() > 0)
                    {
                        int count = ars[0].Count;
                        Article article = ars[0].Article;
                    }
                }
            }

            ArticleReferencePropertyList arpl = new ArticleReferencePropertyList();
            arpl.ARTICLE_MANUFACTURER = "RITTAL";
            ArticleReferencesFilter arf = new ArticleReferencesFilter();
            arf.SetFilteredPropertyList(arpl);

            ArticleReference[] fars = finder.GetArticleReferences(arf);

            foreach (ArticleReference item in fars)
            {
                // MessageBox.Show(string.Format("{0}[{1}]({2})", item.Properties.ARTICLEREF_PARTNO, item.Properties.ARTICLE_MANUFACTURER, item.Count));
            }

            // ArticleReference[] farsws = finder.GetArticleReferencesWithFilterScheme("default"); // P8에서 정의한 스키마로 필터

            //PagePropertyList newppl = new PagePropertyList();
            //// newppl.DESIGNATION_LOCATION = "MULTI";
            //newppl.DESIGNATION_DOCTYPE = "MULTI";
            //newppl.PAGE_COUNTER = "11";
            //newppl.PAGE_NOMINATIOMN = "Insert Macro By API";
            //newppl.PAGE_IDENTNAME = "1011";
            //newppl.PAGE_NUMBER = "11";
            //newppl.PAGE_NAME = "Insert Macro By API";

            //Page newPage = new Page();
            //newPage.Create(project, DocumentTypeManager.DocumentType.Circuit, newppl);

            //Insert insert = new Insert();
            //PointD point = new PointD(100, 250);
            //var resultObject = insert.WindowMacro(@"C:\Users\Public\EPLAN26\Data\Macros\EPlanKorea\m.ema", 0, newPage, point, Insert.MoveKind.Absolute);

            PagePropertyList newppl = new PagePropertyList();
            newppl.DESIGNATION_DOCTYPE = "MULTI";
            newppl.PAGE_COUNTER = "211";
            newppl.PAGE_NOMINATIOMN = "Insert Page Macro By API";
            newppl.PAGE_IDENTNAME = "2011";
            newppl.PAGE_NUMBER = "211";
            newppl.PAGE_NAME = "Insert Page Macro By API";

            Page newPage = new Page();
            newPage.Create(project, DocumentTypeManager.DocumentType.Circuit, newppl);

            Insert insert = new Insert();
            var resultObject = insert.PageMacro(@"C:\Users\Public\EPLAN26\Data\Macros\EPlanKorea\mPage.emp", newPage, project, false, PageMacro.Enums.NumerationMode.Number);

            return true;
        }

        public void GetActionProperties(ref ActionProperties actionProperties)
        {
            // throw new NotImplementedException();
        }

        public bool OnRegister(ref string Name, ref int Ordinal)
        {
            Name = "ActionCheckout";
            Ordinal = 88;
            return true;
        }
    }
}
