using JobSearch.Repositories.Interfaces;
using JobSearch.Repositories.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobSearch.Repositories.Repositories
{
    internal class SkillRepository : ISkillRepository
    {
        private readonly AppContext _context;
        public SkillRepository(AppContext context)
        {
            _context = context;
        }

        public void AddSkill(Tag skill)
        {
            _context.Skills.Add(skill);
            _context.SaveChanges();
        }

        public void DeleteSkill(int id)
        {
            _context.Skills.Remove(GetSkill(id));
            _context.SaveChanges();
        }

        public List<Tag> GetAll()
        {
            return _context.Skills.ToList();
        }

        public Tag GetSkill(int id)
        {
            return _context.Skills.FirstOrDefault(c => c.TagId == id);
        }
    }
}
