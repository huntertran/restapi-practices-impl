package patterns.sample.utils.EntityLinking;

public interface LinkedResource {
    public String accept(ResourceVisitor visitor);
}
