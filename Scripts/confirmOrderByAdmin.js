"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
const $ = require("jquery");
const axios_1 = require("axios");
var ConfirmOrderByAdmin;
(function (ConfirmOrderByAdmin) {
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
            axios_1.default.post("/Orders/ConfirmOrderByAdmin", data).then(res => {
                var data = res.data;
                var success = data.ok;
                if (success) {
                    location.href = "/admin/orders/forAdmin";
                }
            });
        });
    }
    bind();
})(ConfirmOrderByAdmin || (ConfirmOrderByAdmin = {}));
//# sourceMappingURL=confirmOrderByAdmin.js.map