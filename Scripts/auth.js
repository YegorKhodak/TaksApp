"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
const $ = require("jquery");
const axios_1 = require("axios");
var Auth;
(function (Auth) {
    const ui = {
        login: $(".jLogin"),
        password: $(".jPassword"),
        submitBtn: $(".jSubmitBtn"),
        submitAdminBtn: $(".jSubmitAdminBtn"),
        submitBtn2: $(".jSubmitv2"),
        userId: $(".jUserId"),
    };
    function bind() {
        ui.submitBtn.click(() => {
            //asd
            var data = {
                login: ui.login.val(),
                password: ui.password.val()
            };
            axios_1.default.post("/auth/login", data).then(res => {
                var data = res.data;
                var userId = data.userId;
                var success = data.ok;
                if (success) {
                    location.href = "/categories/index?userId=" + userId;
                }
            });
        });
        ui.submitAdminBtn.click(() => {
            //asd
            var data = {
                login: ui.login.val(),
                password: ui.password.val()
            };
            axios_1.default.post("/auth/loginAdmin", data).then(res => {
                var data = res.data;
                var success = data.ok;
                if (success) {
                    location.href = "/admin/orders/forAdmin";
                }
            });
        });
    }
    bind();
})(Auth || (Auth = {}));
//# sourceMappingURL=auth.js.map