using Model.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Models
{
    public class ChatModel : BaseModel
    {
        /// <summary>
        /// 模型名称
        /// </summary>
        public string? Name { get; set; }
        public ModelType Type { get; set; }
        public string? AiType { get; set; }
        public string? ModelName { get; set; }
        public string? Endpoint { get; set; }
        public string? Key { get; set; }
    }
}
