package patterns.sample.utils.EntityLinking;

import patterns.sample.controllers.SampleRelatedResourceController;

public interface ResourceVisitor {
    String visit(SampleRelatedResourceController sampleRelatedResourceController);
}
