package patterns.sample.controllers;

import java.util.concurrent.ExecutorService;
import java.util.concurrent.Executors;
import java.util.concurrent.Future;
import java.util.concurrent.TimeUnit;

import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RestController;

import patterns.sample.services.TimeOutTask;

@RestController
@RequestMapping("/timeout")
public class TimeOutController {

    @GetMapping("/")
    public String get() {
        ExecutorService executor = Executors.newSingleThreadExecutor();
        Future<String> future = executor.submit(new TimeOutTask());

        try {
            System.out.println("Executor started...");
            System.out.println(future.get(3, TimeUnit.SECONDS));
            System.out.println("Executor finished!");
        } catch (Exception e) {
            future.cancel(true);
            System.out.println("Terminated with exception: !" + e.toString());
        }

        return new String("ok");
    }
}
