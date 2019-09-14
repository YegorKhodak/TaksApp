"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
const $ = require("jquery");
const axios_1 = require("axios");
var CreateOrder;
(function (CreateOrder) {
    const ui = {
        confirmOrderBtn: $(".jConfirmOrder"),
        orderId: $(".jOrderId"),
    };
    function bind() {
        ui.confirmOrderBtn.click(() => {
            //asd
            var data = {
                orderId: ui.orderId.val()
            };
            axios_1.default.post("/Orders/ConfirmOrderByUser", data).then(res => {
                var data = res.data;
                var userId = data.userId;
                var success = data.ok;
                if (success) {
                    location.href = "/orders/forUser?userId=" + userId;
                }
            });
        });
    }
    bind();
})(CreateOrder || (CreateOrder = {}));
//# sourceMappingURL=createOrder.js.map