package patterns.sample.controllers;

import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RestController;

import patterns.sample.utils.EntityLinking.LinkedResource;
import patterns.sample.utils.EntityLinking.ResourceVisitor;

@RestController
@RequestMapping("/samplerelatedresource")
public class SampleRelatedResourceController implements LinkedResource {
    @GetMapping("/resource_a")
    public String getA() {
        return "ok";
    }

    @GetMapping("/resource_b")
    public String getB() {
        return "ok";
    }

    @GetMapping("/resource_c")
    public String getC() {
        return "ok";
    }

    @GetMapping("/resource_d")
    public String getD() {
        return "ok";
    }

    @Override
    public String accept(ResourceVisitor visitor) {
        return visitor.visit(this);
    }
}
