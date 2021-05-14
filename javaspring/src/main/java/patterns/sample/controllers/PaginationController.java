package patterns.sample.controllers;

import java.math.BigDecimal;
import java.time.LocalDateTime;
import java.time.ZoneId;
import java.util.ArrayList;
import java.util.Random;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.web.bind.annotation.PostMapping;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RestController;

import patterns.sample.utils.Pagination.Transaction;
import patterns.sample.utils.Pagination.TransactionRepository;

@RestController
@RequestMapping("/pagination")
public class PaginationController {

    @Autowired
    private TransactionRepository transactionRepository;

    @PostMapping("/addsampledata")
    public String addSampleData() {

        Random random = new Random();
        var transactions = new ArrayList<Transaction>();

        for (int i = 0; i < 1000; i++) {
            Transaction newTransaction = new Transaction();
            newTransaction.setId();
            newTransaction.setTime(LocalDateTime.now(ZoneId.of("UTC")));
            newTransaction.setAmount(BigDecimal.valueOf(random.nextDouble()));
            transactions.add(newTransaction);
        }

        transactionRepository.saveAll(transactions);

        return "ok";
    }
}