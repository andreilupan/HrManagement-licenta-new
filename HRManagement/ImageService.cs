using System.IO;
using System.Web;

namespace HRManagement
{
    public class ImageService
    {
        private string uploadDir = @"/EmployeeData/Images";
        public string SaveEmployeeImage(HttpPostedFileBase image, int employeeId)
        {
            if (image != null)
            {
                var imagePath = Path.Combine(HttpContext.Current.Server.MapPath(uploadDir), employeeId.ToString()+"."+Path.GetExtension(image.FileName));
                //var imagePath = Path.Combine(HttpContext.Current.Server.MapPath(uploadDir), employeeId.ToString()+"."+image.FileName.Split('.')[1]);
                var imageUrl = uploadDir + "/" +employeeId.ToString() + "."+(image.FileName.Split('.')[1]);
                image.SaveAs(imagePath);
                return imageUrl;
            }
            return null;
        }

        public string GetEmployeeImageUrl(int employeeId)
        {
            var imagePath = Path.Combine(HttpContext.Current.Server.MapPath(uploadDir), employeeId.ToString());
            var imageUrl = Path.Combine(uploadDir, employeeId.ToString());

            return imageUrl;
        }
    }
}