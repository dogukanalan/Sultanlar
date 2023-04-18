!function (t, e) {
    "object" === typeof exports ? module.exports = e(t) : "function" === typeof define && define.amd ? define([], e(t)) : t.LazyLoadC = e(t)
}("undefined" !== typeof global ? global : this.window || this.global, function (t) {
    "use strict"; function e(t, e) {
        this.settings = r(s, e || {}), this.images = t || document.querySelectorAll(this.settings.selector), this.observer = null, this.init()
    }
    const s =
    {
        src: "data-src",
        srcset: "data-srcset",
        selector: ".lazyloadc"
    },
        r = function () {
            let t = {}, e = !1, s = 0, o = arguments.length; "[object Boolean]" === Object.prototype.toString.call(arguments[0]) && (e = arguments[0], s++); for (; s < o; s++)
                !function (s) {
                    for (let o in s) Object.prototype.hasOwnProperty.call(s, o) && (e && "[object Object]" === Object.prototype.toString.call(s[o]) ? t[o] = r(!0, t[o], s[o]) : t[o] = s[o])
                }(arguments[s]);
            return t
        };
    if (e.prototype =
    {
        init: function () {
            if (!t.IntersectionObserver) return void this.loadImages(); let e = this, s = { root: null, rootMargin: "0px", threshold: [0] };
            this.observer = new IntersectionObserver(function (t) {
                t.forEach(function (t) {
                    if (t.intersectionRatio > 0) {
                        e.observer.unobserve(t.target);
                        let s = t.target.getAttribute(e.settings.src), r = t.target.getAttribute(e.settings.srcset);
                        "img" === t.target.tagName.toLowerCase() ? (s && (t.target.src = s), r && (t.target.srcset = r)) :

                            $.ajax(
                                {
                                    xhr: function () { return xhrDownloadUpload2(); },
                                    url: s,
                                    success: function (data, textStatus, response) {
                                        if (t.target.className.indexOf("llctarih") > -1) {
                                            $(t.target).html(data === "2000-01-01T00:00:00" ? "-" : data.substring(0, 10));
                                        }
                                    }
                                })

                    }
                })
            }, s), this.images.forEach(function (t) { e.observer.observe(t) })
        }, loadAndDestroy: function () { this.settings && (this.loadImages(), this.destroy()) },
        loadImages: function () {
            if (!this.settings) return; let t = this;
            this.images.forEach(function (e) {
                let s = e.getAttribute(t.settings.src), r = e.getAttribute(t.settings.srcset);
                "img" === e.tagName.toLowerCase() ? (s && (e.src = s), r && (e.srcset = r)) :

                    $.ajax(
                        {
                            xhr: function () { return xhrDownloadUpload2(); },
                            url: s,
                            success: function (data, textStatus, response) {
                                if (t.target.className.indexOf("llctarih") > -1) {
                                    $(e).html(data === "2000-01-01T00:00:00" ? "-" : data.substring(0, 10));
                                }
                            }
                        })

            })
        }, destroy: function () {
            this.settings && (this.observer.disconnect(), this.settings = null)
        }
    },
        t.lazyloadc = function (t, s) { return new e(t, s) }, t.jQuery) {
        const s = t.jQuery;
        s.fn.lazyloadc = function (t) { return t = t || {}, t.attribute = t.attribute || "data-src", new e(s.makeArray(this), t), this }
    } return e
});
