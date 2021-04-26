package patterns.sample.utils.EntityLinking;

public interface LinkedResource {
    String accept(ResourceVisitor visitor);
}
