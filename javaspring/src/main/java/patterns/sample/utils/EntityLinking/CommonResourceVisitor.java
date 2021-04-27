package patterns.sample.utils.EntityLinking;

import java.lang.annotation.Annotation;
import java.lang.reflect.Method;
import java.util.ArrayList;
import java.util.Arrays;
import java.util.List;
import java.util.function.Predicate;

import com.google.gson.Gson;

import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.PostMapping;

public abstract class CommonResourceVisitor {

    protected Entity getEntityFromAnnotation(Annotation annotation) {
        String stringified = annotation.toString();
        Entity entity = null;

        if (stringified.contains("GetMapping")) {
            GetMapping getMapping = (GetMapping) annotation;
            entity = new Entity(getMapping.value(), "GET");
        }

        if (stringified.contains("PostMapping")) {
            PostMapping postMapping = (PostMapping) annotation;
            entity = new Entity(postMapping.value(), "POST");
        }

        return entity;
    }

    protected String filterResourcesWithRegexPredicate(Predicate<String> predicate, Method[] methods) {
        List<Entity> entities = new ArrayList<>();

        for (Method method : methods) {
            Annotation[] annotations = method.getAnnotations();

            for (Annotation annotation : annotations) {
                Entity entity = getEntityFromAnnotation(annotation);
                if (entity != null) {
                    if (Arrays.stream(entity.uris).anyMatch(predicate)) {
                        entities.add(entity);
                    }
                }
            }
        }

        Gson gson = new Gson();
        return gson.toJson(entities);
    }
}
