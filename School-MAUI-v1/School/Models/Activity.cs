namespace School;
public class Activity
{
    private Teacher teacher;
    private int ects;
    private string name;
    private string code;

    public Activity(string name, string code, int ECTS, Teacher teacher) {
        this.code = code;
        this.teacher = teacher;
        this.name = name;
        this.ects = ECTS;
    }

    public string Code {
        get {
            return code;
        }
    }

    public string Name {
        get {
            return name;
        }
    }

    public int ECTS {
        get {
            return ects;
        }
    }

    public Teacher Teacher {
        get {
            return teacher;
        }
    }

    public override string ToString()
    {
        return String.Format("[{0}] {1} ({2})", Code, Name, Teacher.DisplayName());
    }
}
