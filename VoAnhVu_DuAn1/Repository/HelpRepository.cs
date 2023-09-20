using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VoAnhVu_DuAn1.Entity;
using VoAnhVu_DuAn1.Model;

namespace VoAnhVu_DuAn1.Repository
{
    public interface IHelpRepository
    {
        List<HelpEntity> getAllHelp();
        void createHelp(HelpEntity help);
        void updateHelp(HelpEntity help);
        bool deleteHelp(string id);
    }
    public class HelpRepository : IHelpRepository
    {
        private readonly MyDbContext _context;
        public HelpRepository(MyDbContext context)
        {
            _context = context;
        }

        public void createHelp(HelpEntity help)
        {
            try
            {
                _context.HelpEntities.Add(help);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool deleteHelp(string id)
        {
            try
            {
                var help = _context.HelpEntities.FirstOrDefault(c => c.HelpId == id);
                if (help is null)
                {
                    return false;
                }
                _context.HelpEntities.Remove(help);
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<HelpEntity> getAllHelp()
        {
            var help = _context.HelpEntities.ToList();
            return help;
        }

        public void updateHelp(HelpEntity help)
        {
            try
            {
                _context.HelpEntities.Update(help);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
