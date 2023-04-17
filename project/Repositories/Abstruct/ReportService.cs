

using project.Models.ReportModels;

namespace project.Repositories.Abstruct
{
    public interface ReportService
    {
        ManageProductsPageModel GetAllNonAprovedProducts(int PageNumber, string operation);
        ManageUsersPageModel GetAllNonAprovedUsers(int PageNumber, string operation);


    }
}
