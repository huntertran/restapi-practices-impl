package patterns.sample.utils.EntityLinking;

import java.util.function.Predicate;
import java.util.regex.Pattern;

import patterns.sample.controllers.SampleRelatedResourceController;

// put these logics in abstract class for reuse
// template method
public class LogicCDResourceVisitor extends CommonResourceVisitor
                                    implements ResourceVisitor {

    @Override
    public String visit(SampleRelatedResourceController sampleRelatedResourceController) {

        Predicate<String> predicate = Pattern.compile("(?:\\/resource_c)|(?:\\/resource_d)").asMatchPredicate();

        return filterResourcesWithRegexPredicate(predicate);
    }
}
