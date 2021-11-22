var more_text = 'اقرأ المزيد';
var no_image = "https://1.bp.blogspot.com/-OQTT8OprpKI/Xses6gXJp6I/AAAAAAAAA88/j2ubRv-pRqUPrs8ZS9EP2O-m-t7a66kZACLcBGAsYHQ/s400/no-image.png",
    months = [, " يناير", " فبراير", " مارس", " أبريل", " ماي", " يونيو", " يوليوز", " غشت", " شتنبر", " أكتوبر", " نونبر", " دجنبر"],
    days = ['الأحد', 'الاثنين', 'الثلاثاء', 'الاربعاء', 'الخميس', 'الجمعة', 'السبت'],
    more_text = "عرض المزيد",
    related_number = 4,
    snippet_count = 150;$(".slider").each(function () {
    var t = $(this),
        e = t.attr("data-option"),
        l = t.attr("data-no"),
        r = t.attr("data-no"),
        i = (t.attr("data-slide"), t.attr("data-type")),
        o = t.parent().parent(),
        n = Math.floor(Math.random() * l + 1);
    if (o.find("h3.title").remove(), e.match("أحدث المواضيع")) var p = "/feeds/posts/default?alt=json-in-script&max-results=" + l;
    else p = e.match("مواضيع عشوائية") ? "/feeds/posts/default?alt=json-in-script&orderby=updated&start-index=" + n + "&max-results=" + l : "/feeds/posts/default/-/" + e + "?alt=json-in-script&max-results=" + l;
    $.ajax({
        type: "GET",
        url: p,
        dataType: "jsonp",
        success: function (t) {
            for (var l = '<div class="' + i + '"><h2 class="title"><strong>' + e + '</strong><a class="getmore" href="/search/label/' + e + '?&amp;max-results=9"><strong>' + more_text + '</strong></a></h2><div class="bylabel"><div class="lk_wrapper"><ul class="lk owl-carousel">', o = "", n = 0; n < t.feed.entry.length; n++) {
                for (var p = t.feed.entry[n], g = p.title.$t, h = 0; h < p.link.length; h++)
                    if ("replies" == p.link[h].rel && "text/html" == p.link[h].type && (p.link[h].title, p.link[h].href), "alternate" == p.link[h].rel) {
                        var m = p.link[h].href;
                        break
                    } var f, u = p.content.$t,
                    v = t.feed.entry[n].author[0].name.$t,
                    w = (t.feed.entry[n].author[0].gd$image.src, t.feed.entry[n].published.$t),
                    y = w.substring(0, 4),
                    x = w.substring(5, 7),
                    k = w.substring(8, 10) + " " + months[parseInt(x, 10)] + " " + y,
                    C = ($("<p>").html(u).text().substring(0, 65), ""),
                    A = "";
                try {
                    f = p.media$thumbnail.url.replace("default", "hqdefault")
                } catch (t) {
                    s = p.content.$t, a = s.indexOf("<img"), b = s.indexOf('src="', a), c = s.indexOf('"', b + 5), d = s.substr(b + 5, c - b - 5), f = -1 != a && -1 != b && -1 != c && "" != d ? d : "https://1.bp.blogspot.com/-OQTT8OprpKI/Xses6gXJp6I/AAAAAAAAA88/j2ubRv-pRqUPrs8ZS9EP2O-m-t7a66kZACLcBGAsYHQ/w500-h365-c/no-image.png"
                }
                try {
                    C = p.category[0].term, tgg = C.slice(0, 1)
                } catch (l) {
                    C = "", A = "notag", tgg = ""
                }
                o += '<li class="lk_item">', o += '<div class="lk_image"><a href="' + m + '" title="' + g + '"><img alt="' + g + '" src="' + f.replace("s72", "s400") + '"></img></a></div>', o += '<div class="lk_description">', o += '<span class="lk_tag ' + tgg + '"><a class="tag ' + A + '" href="/search/label/' + C + '" title="' + C + '">' + C + "</a></span>", o += '<span class="lk_title"><a href="' + m + '" title="' + g + '">' + g + "</a></span>", o += '<span class="lk_meta"><a><svg aria-hidden="true" class="user-icon" data-icon="user" data-prefix="far" role="img" viewBox="0 0 45.532 45.532" xmlns="http://www.w3.org/2000/svg"><g xmlns="http://www.w3.org/2000/svg"><path fill="currentColor" d="M22.766,0.001C10.194,0.001,0,10.193,0,22.766s10.193,22.765,22.766,22.765c12.574,0,22.766-10.192,22.766-22.765   S35.34,0.001,22.766,0.001z M22.766,6.808c4.16,0,7.531,3.372,7.531,7.53c0,4.159-3.371,7.53-7.531,7.53   c-4.158,0-7.529-3.371-7.529-7.53C15.237,10.18,18.608,6.808,22.766,6.808z M22.761,39.579c-4.149,0-7.949-1.511-10.88-4.012   c-0.714-0.609-1.126-1.502-1.126-2.439c0-4.217,3.413-7.592,7.631-7.592h8.762c4.219,0,7.619,3.375,7.619,7.592   c0,0.938-0.41,1.829-1.125,2.438C30.712,38.068,26.911,39.579,22.761,39.579z"></path></g></svg>' + v + '</a><a><svg aria-hidden="true" class="date-icon" data-icon="date" data-prefix="far" role="img" viewBox="0 0 559.98 559.98" xmlns="http://www.w3.org/2000/svg"><g xmlns="http://www.w3.org/2000/svg"><path fill="currentColor" d="M279.99,0C125.601,0,0,125.601,0,279.99c0,154.39,125.601,279.99,279.99,279.99c154.39,0,279.99-125.601,279.99-279.99    C559.98,125.601,434.38,0,279.99,0z M279.99,498.78c-120.644,0-218.79-98.146-218.79-218.79    c0-120.638,98.146-218.79,218.79-218.79s218.79,98.152,218.79,218.79C498.78,400.634,400.634,498.78,279.99,498.78z"></path><path fill="currentColor" d="M304.226,280.326V162.976c0-13.103-10.618-23.721-23.716-23.721c-13.102,0-23.721,10.618-23.721,23.721v124.928    c0,0.373,0.092,0.723,0.11,1.096c-0.312,6.45,1.91,12.999,6.836,17.926l88.343,88.336c9.266,9.266,24.284,9.266,33.543,0    c9.26-9.266,9.266-24.284,0-33.544L304.226,280.326z"></path></g></svg>' + k + "</a></span>", o += "</div>", o += "</li>"
            }
            l += o += "</ul></div></div></div>", $(".slider").each(function () {
                $(this).attr("data-option") == e && $(this).attr("data-type") == i && $(this).attr("data-no") == r && $(this).parent().html(l)
            }), $(".m-slider .lk.owl-carousel").owlCarousel({
                autoplay: !0,
                lazyLoad: true,
                loop: !0,
                margin: 0,
                responsiveClass: !0,
                autoHeight: !0,
                rtl: !0,
                autoplayTimeout: 7e3,
                smartSpeed: 800,
                nav: true,
                dots: true,
                navText: ['<i class="catch fa fa-angle-right"></i>', '<i class="catch fa fa-angle-left"></i>'],
                responsive: {
                    0: {
                        items: 1
                    },
                    600: {
                        items: 2
                    },
                    1024: {
                        items: 3
                    },
                    1366: {
                        items: 3
                    }
                }
            }), $(".d-slider .lk.owl-carousel").owlCarousel({
                autoplay: !0,
                lazyLoad: true,
                loop: !0,
                margin: 20,
                responsiveClass: !0,
                autoHeight: !0,
                rtl: !0,
                autoplayTimeout: 3000,
                smartSpeed: 3000,
                nav: false,
                dots: true,
                navText: ['<i class="catch fa fa-angle-right"></i>', '<i class="catch fa fa-angle-left"></i>'],
                responsive: {
                    0: {
                        items: 1
                    },
                    600: {
                        items: 3
                    },
                    1024: {
                        items: 3
                    },
                    1366: {
                        items: 4
                    }
                }
            }), $(".f-slider .lk.owl-carousel").owlCarousel({
                autoplay: !1,
                lazyLoad: true,
                loop: !0,
                margin: 20,
                responsiveClass: !0,
                autoHeight: !0,
                rtl: !0,
                autoplayTimeout: 7e3,
                smartSpeed: 800,
                nav: !0,
                dots: !0,
                navText: ['<i class="catch fa fa-angle-right"></i>', '<i class="catch fa fa-angle-left"></i>'],
                responsive: {
                    0: {
                        items: 2
                    },
                    600: {
                        items: 3
                    },
                    1024: {
                        items: 3
                    },
                    1366: {
                        items: 4
                    }
                }
            }), $(".s-slider .lk.owl-carousel").owlCarousel({
                autoplay: !1,
                lazyLoad: true,
                loop: !0,
                margin: 10,
                responsiveClass: !0,
                autoHeight: !0,
                rtl: !0,
                autoplayTimeout: 7e3,
                smartSpeed: 800,
                nav: !1,
                dots: !0,
                navText: ['<i class="catch fa fa-angle-right"></i>', '<i class="catch fa fa-angle-left"></i>'],
                responsive: {
                    0: {
                        items: 2
                    },
                    600: {
                        items: 3
                    },
                    1024: {
                        items: 1
                    },
                    1366: {
                        items: 1
                    }
                }
            })
        }
    })
