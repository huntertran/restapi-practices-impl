package patterns.sample.utils.EntityLinking;

import java.lang.reflect.Method;
import java.util.function.Predicate;
import java.util.regex.Pattern;

import patterns.sample.controllers.SampleRelatedResourceController;

// put these logics in abstract class for reuse
// template method
public class LogicABResourceVisitor extends CommonResourceVisitor
                                    implements ResourceVisitor {

    @Override
    public String visit(SampleRelatedResourceController sampleRelatedResourceController) {

        Predicate<String> predicate = Pattern.compile("(?:\\/resource_a)|(?:\\/resource_b)").asMatchPredicate();
        Method[] methods = SampleRelatedResourceController.class.getMethods();

        return filterResourcesWithRegexPredicate(predicate, methods);
    }
}
