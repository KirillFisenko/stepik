public class Lesson
{
    public int Id { get; set; }
    public string Title { get; set; }
    public int EpicCount { get; set; }
    public int AbuseCount { get; set; }

    public List<UnitLesson> UnitLessons { get; set; }
    public List<Step> Steps { get; set; }
}
