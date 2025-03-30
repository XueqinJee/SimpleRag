using Model.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Models
{
    public class KnowledgeInfo : BaseModel
    {
        public string? FileName { get; set; }
        public int Size { get; set; }
        public int Chunks { get; set; }
        public FileStateEnum State { get; set; }

        [ForeignKey(nameof(Knowledge))]
        public int KnowledgeId { get; set; }

        public Knowledge? knowledge { get; set; }
    }
}
