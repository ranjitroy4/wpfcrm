using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using SisComWpf.Controller;
using System.Windows;
using SisComWpf.view.search;
using SisComWpf.View.Search;

namespace SisComWpf.View {

    public class CommonView {
        /// <summary>
        /// Limpa todos os campos de um contâiner
        /// </summary>
        /// <param name="panel"></param>
        public static void ClearFields(Panel panel) {
            foreach (TextBox ctrl in panel.Children.OfType<TextBox>()) {
                ctrl.Text = string.Empty;
            }
        }

        public static MessageBoxResult YesNoMsgBox(string sMessage) {
            return MessageBox.Show(sMessage, "Sistema", MessageBoxButton.YesNo, MessageBoxImage.Question);
        }

        public static void CreateViewObject(Panel panel, IDefaultView iView) {
            // Uma nova instância é criada para cada solicitação do usuário
            // var ucToShow = Activator.CreateInstance(iView.GetType()) as UserControl;
            // Substituída a linha acima pela fábrica
            var ucToShow = ViewFactory.BuildUserContol(iView);
            var controller = CtrlFactory.BuildControllerByUC(ucToShow);
            BindViewToPanel(panel, controller, iView, ucToShow);
        }

        public static void CreateViewObject(Panel panel, IDefaultView iView, Object dataObject) {
            var controller = CtrlFactory.BuildRegControllerByDO(dataObject.GetType());
            BindViewToPanel(panel, controller, iView, (UserControl)iView);
        }

        private static void BindViewToPanel(Panel panel, IDefaultCtrl iCtrl, IDefaultView iView, UserControl userControl) {
            // Garante apenas que um elemento do tipo IDefaultView permaneça aberto por vez
            var view = panel.Children.OfType<IDefaultView>().FirstOrDefault();
            panel.Children.Remove(view as UIElement);

            // Esta dependência não ficou legal
            ((IDefaultView)userControl).BusinessObject = iCtrl;
            iCtrl.View = ((IDefaultView)userControl);
            panel.Children.Add(userControl);
        }

        public static SearchWindow BuildSearchWindow(SearchType searchType) {
            SearchWindow searchWindow = new SearchWindow();
            searchWindow.SearchFor = searchType;
            var iCtrl = CtrlFactory.BuildControllerByUC(searchWindow.ucSearch);
            iCtrl.View = searchWindow;
            searchWindow.BusinessObject = iCtrl;

            return searchWindow;
        }
    }
}