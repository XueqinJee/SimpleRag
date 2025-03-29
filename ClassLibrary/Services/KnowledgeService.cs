using Microsoft.EntityFrameworkCore;
using Model;
using Model.Models;

namespace ClassLibrary.Services
{
    public class KnowledgeService(
        MyDbContext _myDbContext)
    {
        public async Task<bool> AddKnowledge(Knowledge model) {
            _myDbContext.Knowledge.Add(model);
            var result = await _myDbContext.SaveChangesAsync();
            return result > 0;
        }

        public async Task<bool> UpdateKnowledge(Knowledge model) {
            var first = await _myDbContext.Knowledge.FirstOrDefaultAsync(x => x.Id == model.Id);
            if(first == null) {
                return false;
            }

            first.Name = model.Name;
            first.Icon = model.Description;
            first.EmbeddedId = model.EmbeddedId;
            first.Description = model.Description;
            return await _myDbContext.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteById(int id) {
            var data = await GetKnowledgeById(id);
            if(data == null) {
                return true;
            }
            _myDbContext.Knowledge.Remove(data);
            return await _myDbContext.SaveChangesAsync() > 0;
        }

        public async Task<List<Knowledge>> GetKnowledgeList() {
            return await _myDbContext.Knowledge.ToListAsync();
        }

        public async Task<Knowledge?> GetKnowledgeById(int? id) {
            var first = await _myDbContext.Knowledge.FirstOrDefaultAsync(x => x.Id == id);
            if(first == null) {
                return null;
            }
            return first;
        }
    }
}
