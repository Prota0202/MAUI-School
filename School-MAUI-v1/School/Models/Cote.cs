namespace School;
public class Cote : Evaluation
{
    private int note;

    public Cote(Activity activity, int note) : base(activity) {
        SetNote(note);
    }

    public Cote(Activity activity) : base(activity) {
        SetNote(0);
    }

    public void SetNote(int note) {
        this.note = note;
    }

    public override int Note()
    {
        return note;
    }
}
