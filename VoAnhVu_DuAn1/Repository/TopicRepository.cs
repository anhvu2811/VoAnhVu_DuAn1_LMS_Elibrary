using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VoAnhVu_DuAn1.Entity;
using VoAnhVu_DuAn1.Model;

namespace VoAnhVu_DuAn1.Repository
{
    public interface ITopicRepository
    {
        List<TopicEntity> getAllTopic();
        void createTopic(TopicEntity topic);
        void updateTopic(TopicEntity topic);
        bool deleteTopic(string id);
    }
    public class TopicRepository : ITopicRepository
    {
        private readonly MyDbContext _context;
        public TopicRepository(MyDbContext context)
        {
            _context = context;
        }

        public void createTopic(TopicEntity topic)
        {
            try
            {
                _context.TopicEntities.Add(topic);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool deleteTopic(string id)
        {
            try
            {
                var topic = _context.TopicEntities.FirstOrDefault(c => c.TopicId == id);
                if (topic is null)
                {
                    return false;
                }
                _context.TopicEntities.Remove(topic);
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<TopicEntity> getAllTopic()
        {
            var topic = _context.TopicEntities.ToList();
            return topic;
        }

        public void updateTopic(TopicEntity topic)
        {
            try
            {
                _context.TopicEntities.Update(topic);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
