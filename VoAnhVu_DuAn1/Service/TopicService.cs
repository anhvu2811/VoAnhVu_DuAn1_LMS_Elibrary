using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VoAnhVu_DuAn1.Entity;
using VoAnhVu_DuAn1.Repository;

namespace VoAnhVu_DuAn1.Service
{
    public interface ITopicService
    {
        List<TopicEntity> getAllTopic();
        void createTopic(TopicEntity topic);
        void updateTopic(TopicEntity topic);
        bool deleteTopic(string id);
    }
    public class TopicService : ITopicService
    {
        private readonly ITopicRepository _topicRepository;
        public TopicService(ITopicRepository topicRepository)
        {
            _topicRepository = topicRepository;
        }

        public void createTopic(TopicEntity topic)
        {
            _topicRepository.createTopic(topic);
        }

        public bool deleteTopic(string id)
        {
            bool topic = _topicRepository.deleteTopic(id);
            if (!topic)
            {
                return false;
            }
            return true;
        }

        public List<TopicEntity> getAllTopic()
        {
            return _topicRepository.getAllTopic().ToList();
        }

        public void updateTopic(TopicEntity topic)
        {
            _topicRepository.updateTopic(topic);
        }
    }
}
