using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VoAnhVu_DuAn1.Model;
using VoAnhVu_DuAn1.Entity;
using Microsoft.EntityFrameworkCore;

namespace VoAnhVu_DuAn1.Repository
{
    public interface IHelpRepository
    {
        List<HelpModel> getAllHelp();
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

        public List<HelpModel> getAllHelp()
        {
            var helps = _context.HelpEntities
             .Include(help => help.User)
             .Select(help => new HelpModel
             {
                 HelpId = help.HelpId,
                 Title = help.Title,
                 Content = help.Content,
                 User = help.User
             }).ToList();
            return helps;
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
