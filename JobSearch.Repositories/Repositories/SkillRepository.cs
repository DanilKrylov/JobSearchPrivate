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

        public void AddSkill(Skill skill)
        {
            _context.Skills.Add(skill);
            _context.SaveChanges();
        }

        public List<Skill> GetAll()
        {
            return _context.Skills.ToList();
        }

        public Skill GetSkill(int id)
        {
            return _context.Skills.FirstOrDefault(c => c.SkillId == id);
        }
    }
}
