using ClassLibrary.Services.Base;
using Model;
using Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.Services
{
    public class KnowledgeInfoService : GenericRepository<KnowledgeInfo>{
        private readonly MyDbContext _myDbContext;
        public KnowledgeInfoService(MyDbContext myDbContext) : base(myDbContext){
            _myDbContext = myDbContext;
        }


    }
}
