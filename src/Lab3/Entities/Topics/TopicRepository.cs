using System;
using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab3.Exceptions;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities.Topics;

public class TopicRepository
{
    private readonly Dictionary<string, Topic> _topicsByName;

    public TopicRepository(IEnumerable<Topic>? topics = null)
    {
        _topicsByName = topics?.ToDictionary(topic => topic.Name) ?? new Dictionary<string, Topic>();
    }

    public void Add(Topic topic)
    {
        ArgumentNullException.ThrowIfNull(topic);

        _topicsByName.Add(topic.Name, topic);
    }

    public void Remove(Topic topic)
    {
        ArgumentNullException.ThrowIfNull(topic);

        _topicsByName.Remove(topic.Name);
    }

    public Topic Get(string name)
    {
        ArgumentNullException.ThrowIfNull(name);

        return _topicsByName.TryGetValue(name, out Topic? topic) ? topic : throw new InvalidTopicNameException();
    }
}