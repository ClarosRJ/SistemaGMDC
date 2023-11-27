using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sis.Alcaldia.Shared.BaseModels
{
    public class SaveFileDTO
    {
        public SaveFileDTO()
        {
            Files = new List<FileDataDTO>();
        }
        public List<FileDataDTO> Files { get; set; }
    }

    public class FileDataDTO
    {
        public byte[] ImageBytes { get; set; }
        public string ImagenInicio { get; set; }
        public string FileName { get; set; }
        public string FileType { get; set; }
        public long FileSize { get; set; }
    }
}
