using Microsoft.AspNetCore.Mvc;

namespace PortfolioTemplate.Models
{
    public class AlertHelper
    {
        // Sweet Alert İçin Ortak Alan //
        private readonly Controller _controller;

        public AlertHelper(Controller controller)
        {
            _controller = controller;
        }

        public void SweetAlertShow(string type, string state)
        {
            _controller.TempData["SweetAlertMessage"] = "success";
            _controller.TempData["SweetAlertTitle"] = "Başarı";
            _controller.TempData["SweetAlertText"] = type + "  Basariyla " + state;
            _controller.TempData["SweetAlertConfirmText"] = "Tamam";
        }
    }
}
