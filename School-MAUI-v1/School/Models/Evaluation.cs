namespace School;
public abstract class Evaluation
{
    private Activity activity;

    public Evaluation(Activity activity) {
        this.activity = activity;
    }

    public Activity Activity {
        get {
            return activity;
        }
    }

    public abstract int Note();

    public override string ToString()
    {
        return String.Format("{0}: {1}/20", Activity, Note());
    }
    public int NoteValue
    {
        get { return Note(); }
    }
}
