namespace FitnessApp.Web.ViewModels.Models
{
    public class ErrorViewModel
	{
		public string? RequestId { get; set; }

		public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
	}
}