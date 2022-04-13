stripeCheckout = function(sessionId) {
    var stripe = Stripe("pk_test_51KXsvmFJXN6PQCt7JfhEWI545YFipE5D5imBNjN3Qidd0Rc13nBSeonAEQB6ST4fucDwfMcEcfL0dwMilMguG3Uc00hLo2N173");

    stripe.redirectToCheckout({
         sessionId: sessionId
    });
};