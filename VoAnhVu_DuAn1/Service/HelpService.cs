using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VoAnhVu_DuAn1.Entity;
using VoAnhVu_DuAn1.Repository;

namespace VoAnhVu_DuAn1.Service
{
    public interface IHelpService
    {
        List<HelpEntity> getAllHelp();
        void createHelp(HelpEntity help);
        void updateHelp(HelpEntity help);
        bool deleteHelp(string id);
    }
    public class HelpService : IHelpService
    {
        private readonly IHelpRepository _helpRepository;
        public HelpService(IHelpRepository helpRepository)
        {
            _helpRepository = helpRepository;
        }

        public void createHelp(HelpEntity help)
        {
            _helpRepository.createHelp(help);
        }

        public bool deleteHelp(string id)
        {
            bool help = _helpRepository.deleteHelp(id);
            if (!help)
            {
                return false;
            }
            return true;
        }

        public List<HelpEntity> getAllHelp()
        {
            return _helpRepository.getAllHelp().ToList();
        }

        public void updateHelp(HelpEntity help)
        {
            _helpRepository.updateHelp(help);
        }
    }
}
