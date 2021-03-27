public class ProjectileData : ProjectileDataBase
{
    public ProjectileData(ProjectileGeneratorDataBase projectileGeneratorDataBase = null)
    {
        ProjectileDamage = projectileGeneratorDataBase.ProjectileDamage;
    }
}
