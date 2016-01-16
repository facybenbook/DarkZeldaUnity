public class TeleportInfo
{
    public string id;
    public string SceneName;
    public Facing facing;
 
    public TeleportInfo(string id, string scenename, Facing facing)
    {
        this.id = id;
        this.SceneName = scenename;
        this.facing = facing;
    }
}