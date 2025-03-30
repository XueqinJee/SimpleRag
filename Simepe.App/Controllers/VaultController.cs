using Microsoft.AspNetCore.Mvc;
using Microsoft.Net.Http.Headers;
using Simepe.App.ViewModel;
using Tools;

namespace Simepe.App.Controllers {

    [ApiController]
    [Route("/api/[Controller]")]
    public class VaultController : ControllerBase {
        private readonly string _basePath = string.Empty;

        public VaultController() {
            _basePath = Utility.GetAppDomainRootPath() + "Vault";
        }

        [HttpPost("Upload")]
        public async Task<IActionResult> UploadFile(List<IFormFile> files) {
            long size = files.Sum(x => x.Length);

            List<VaultUploadFileViewModel> datas = new List<VaultUploadFileViewModel>();
            foreach (var item in files) {
                string fileName = @$"{Guid.NewGuid().ToString()}-{item.FileName}";

                if (!Directory.Exists(_basePath)) {
                    Directory.CreateDirectory(_basePath);
                }
                var filePath = _basePath + @$"\{fileName}";

                using (var stream = System.IO.File.Create(filePath)) {
                    await item.CopyToAsync(stream);
                }

                datas.Add(new VaultUploadFileViewModel {
                    Name = fileName,
                    Size = (int)item.Length,
                    Path = $"Vault\\" + fileName,
                    Url = "",
                    Type = item.ContentType
                });
            }

            return Ok(datas);
        }

        [HttpGet("File/{FileName}")]
        public Task<FileStreamResult> Download(string FileName) {

            string file = _basePath + @$"\{FileName}";
            if (!System.IO.File.Exists(file)) {
                throw new FileNotFoundException($"{file} 文件不存在！");
            }

            var stream = System.IO.File.Open(file, FileMode.Open);
            var result = new FileStreamResult(stream, new MediaTypeHeaderValue("application/pdf"));
            result.FileDownloadName = "测试.pdf";
            return Task.FromResult(result);
        }
    }
}
