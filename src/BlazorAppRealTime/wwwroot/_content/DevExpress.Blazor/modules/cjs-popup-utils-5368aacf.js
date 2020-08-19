DxBlazorInternal.define("cjs-popup-utils-5368aacf.js",(function(t,e,o){t("./cjs-chunk-9eab2df8.js");var i=t("./cjs-chunk-f9f4d45f.js"),n=t("./cjs-chunk-e26655d2.js"),r="\\s*matrix\\(\\s*"+[0,0,0,0,0,0].map((function(){return"(\\-?\\d+\\.?\\d*)"})).join(",\\s*")+"\\)\\s*";function s(t){var e=0;if(null!=t&&""!=t)try{var o=t.indexOf("px");o>-1&&(e=parseFloat(t.substr(0,o)))}catch(t){}return Math.ceil(e)}function l(t){var e=new RegExp(r).exec(t.transform);return e?{left:parseInt(e[5]),top:parseInt(e[6])}:{left:0,top:0}}function a(t,e,o){t.transform="matrix(1, 0, 0, 1, "+e+", "+o+")"}function h(t,e,o){var i=t.getBoundingClientRect(),n={left:e(i.left),top:e(i.top),right:o(i.right),bottom:o(i.bottom)};return n.width=n.right-n.left,n.height=n.bottom-n.top,n}function f(t){return h(t,Math.floor,Math.ceil)}function c(t){return h(t,Math.ceil,Math.floor)}var p=function(t,e){this.key=t,this.info=e};p.prototype.checkMargin=function(){return!0},p.prototype.allowScroll=function(){return"height"===this.info.size},p.prototype.canApplyToElement=function(t){return i.GetClassName(t).indexOf("dxbs-align-"+this.key)>-1},p.prototype.getRange=function(t){var e=this.getTargetBox(t)[this.info.to],o=e+this.info.sizeM*(t.elementBox[this.info.size]+(this.checkMargin()?t.margin:0));return{from:Math.min(e,o),to:Math.max(e,o),windowOverflow:0}},p.prototype.getTargetBox=function(t){return null},p.prototype.validate=function(t,e){var o=e[this.info.size];return t.windowOverflow=Math.abs(Math.min(0,t.from-o.from)+Math.min(0,o.to-t.to)),t.validTo=Math.min(t.to,o.to),t.validFrom=Math.max(t.from,o.from),0===t.windowOverflow},p.prototype.applyRange=function(t,e){e.appliedModifierKeys[this.info.size]=this.key;var o="width"===this.info.size?"left":"top",i=e.styles,r=t.from;this.allowScroll()&&t.windowOverflow>0&&(e.limitBox.scroll.width||(e.limitBox.scroll.width=!0,e.limitBox.width.to-=n.GetVerticalScrollBarWidth()),e.isScrollable&&(i["max-height"]=e.height-t.windowOverflow+"px",e.width+=n.GetVerticalScrollBarWidth(),e.elementBox.width+=n.GetVerticalScrollBarWidth(),r=t.validFrom)),i.width=e.width+"px",this.checkMargin()&&(r+=Math.max(0,this.info.sizeM)*e.margin),e.elementBox[o]+=r,a(i,e.elementBox.left,e.elementBox.top)},p.prototype.dockElementToTarget=function(t){var e=this.getRange(t);this.dockElementToTargetInternal(e,t)||this.applyRange(e,t)},p.prototype.dockElementToTargetInternal=function(t,e){};var d=function(t){function e(e,o,i){t.call(this,e,o,i),this.oppositePointName=i||null}return t&&(e.__proto__=t),(e.prototype=Object.create(t&&t.prototype)).constructor=e,e.prototype.getTargetBox=function(t){return t.targetBox.outer},e.prototype.getOppositePoint=function(){return this._oppositePoint||(this._oppositePoint=m.filter(function(t){return t.key===this.oppositePointName}.bind(this))[0])},e.prototype.dockElementToTargetInternal=function(t,e){if(this.validate(t,e.limitBox))this.applyRange(t,e);else{var o=this.getOppositePoint(),i=o.getRange(e);if(!(o.validate(i,e.limitBox)||i.windowOverflow<t.windowOverflow))return!1;o.applyRange(i,e)}return!0},e}(p),u=function(t){function e(){t.apply(this,arguments)}return t&&(e.__proto__=t),(e.prototype=Object.create(t&&t.prototype)).constructor=e,e.prototype.checkMargin=function(){return!1},e.prototype.getTargetBox=function(t){return t.targetBox.inner},e.prototype.dockElementToTargetInternal=function(t,e){return this.validate(t,e.limitBox),!1},e.prototype.validate=function(e,o){var i=Math.min(e.from,Math.max(0,e.to-o[this.info.size].to));return i>0&&(e.from-=i,e.to-=i),t.prototype.validate.call(this,e,o)},e}(p),m=[new d("above",{to:"top",from:"bottom",size:"height",sizeM:-1},"below"),new d("below",{to:"bottom",from:"top",size:"height",sizeM:1},"above"),new u("top-sides",{to:"top",from:"top",size:"height",sizeM:1}),new u("bottom-sides",{to:"bottom",from:"bottom",size:"height",sizeM:-1}),new d("outside-left",{to:"left",from:"right",size:"width",sizeM:-1},"outside-right"),new d("outside-right",{to:"right",from:"left",size:"width",sizeM:1},"outside-left"),new u("left-sides",{to:"left",from:"left",size:"width",sizeM:1}),new u("right-sides",{to:"right",from:"right",size:"width",sizeM:-1})];function g(t,e,o,n){return i.changeDom((function(){for(var r=function(t,e,o){var n,r,a,h,p=i.GetCurrentStyleSheet(),d=f(t),u=c(e),g=t.ownerDocument.documentElement,w={isScrollable:i.ElementHasCssClass(t,"dxbs-scrollable"),specifiedOffsetModifiers:m.filter((function(e){return e.canApplyToElement(t)})),margin:s(p.marginTop),width:o?Math.max(o.width,Math.ceil(t.offsetWidth)):Math.ceil(t.offsetWidth),height:Math.ceil(t.offsetHeight),appliedModifierKeys:{height:null,width:null}},y=l(p),M=t.classList.contains("visually-hidden")?u.left:d.left;w.elementBox={left:n=y.left-M,top:r=y.top-d.top,right:n+(a=d.width),bottom:r+(h=d.height),width:a,height:h},w.targetBox={outer:f(e),inner:c(e)},w.limitBox={scroll:{width:g.clientWidth<window.innerWidth,height:g.clientHeight<window.innerHeight},width:{from:0,to:g.clientWidth},height:{from:0,to:g.clientHeight}},w.styles={};var x=(t.getAttribute("data-popup-align")||o&&o.align).split(/\s+/);return w.offsetModifiers=m.filter((function(t){return x.some((function(e){return t.key===e}))})),w}(t,e,o),a=0;a<r.offsetModifiers.length;a++)r.offsetModifiers[a].dockElementToTarget(r);n(r),i.setStyles(t,r.styles)}))}o.hide=function(t){i.ElementHasCssClass(t,"show")?(t.isDockedElementHidden&&delete t.isDockedElementHidden,i.clearStyles(t),i.toggleCssClass(t,"show",!1)):t.isDockedElementHidden&&delete t.isDockedElementHidden},o.parseTranslateInfo=l,o.show=function(t,e,o){null!==e&&(g(t,e,{align:o},(function(){})),i.toggleCssClass(t,"show",!0),i.clearStyles(t))},o.translatePosition=a}),["cjs-chunk-9eab2df8.js","cjs-chunk-f9f4d45f.js","cjs-chunk-e26655d2.js"]);
