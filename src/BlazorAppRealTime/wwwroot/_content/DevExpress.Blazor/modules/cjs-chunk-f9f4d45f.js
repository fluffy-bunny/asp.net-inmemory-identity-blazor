DxBlazorInternal.define("cjs-chunk-f9f4d45f.js",(function(e,t,n){var r=e("./cjs-chunk-9eab2df8.js");function o(e){return function(e,t,n){var r=e.length;if(!r)return e;if(r<764833){var o=e;return t&&(o=o.replace(/^\s+/,"")),n&&(o=o.replace(/\s+$/,"")),o}var u=0;if(n)for(;r>0&&i[e.charCodeAt(r-1)];)r--;if(t&&r>0)for(;u<r&&i[e.charCodeAt(u)];)u++;return e.substring(u,r)}(e,!0,!0)}var i={9:1,10:1,11:1,12:1,13:1,32:1,133:1,160:1,5760:1,6158:1,8192:1,8193:1,8194:1,8195:1,8196:1,8197:1,8198:1,8199:1,8200:1,8201:1,8202:1,8203:1,8232:1,8233:1,8239:1,8287:1,12288:1};var u,l=document.body,s=new WeakMap,a=new Map,c={subtree:!0,childList:!0},d=new MutationObserver((function(e){e.forEach(f)}));function f(e){e.removedNodes.forEach(m)}function m(e){var t=a.get(e);a.delete(e)&&(0===a.size&&d.disconnect(),t())}function h(e){if("object"!=typeof e||null==e)return e;var t={};for(var n in e)t[n]=e[n];return t}function p(){var e=r.Browser.IE&&"hidden"==D(document.body).overflow&&document.body.scrollLeft>0;return r.Browser.Edge||e?document.body?document.body.scrollLeft:document.documentElement.scrollLeft:r.Browser.WebKitFamily?document.documentElement.scrollLeft||document.body.scrollLeft:document.documentElement.scrollLeft}function g(){var e=r.Browser.IE&&"hidden"==D(document.body).overflow&&document.body.scrollTop>0;return r.Browser.WebKitFamily||r.Browser.Edge||e?r.Browser.MacOSMobilePlatform?window.pageYOffset:r.Browser.WebKitFamily&&document.documentElement.scrollTop||document.body.scrollTop:document.documentElement.scrollTop}function v(){if(void 0===u){var e=document.createElement("DIV");e.style.cssText="position: absolute; top: 0px; left: 0px; visibility: hidden; width: 200px; height: 150px; overflow: hidden; box-sizing: content-box",document.body.appendChild(e);var t=document.createElement("P");e.appendChild(t),t.style.cssText="width: 100%; height: 200px;";var n=t.offsetWidth;e.style.overflow="scroll";var r=t.offsetWidth;n==r&&(r=e.clientWidth),u=n-r,document.body.removeChild(e)}return u}function y(e){return b(e)}function w(e){return S(e)}function b(e){return r.Browser.IE?function(e){if(null==e||r.Browser.IE&&null==e.parentNode)return 0;return e.getBoundingClientRect().left+p()}(e):r.Browser.Firefox&&r.Browser.Version>=3||r.Browser.WebKitFamily||r.Browser.Edge?E(e):getAbsolutePositionX_Other(e)}function E(e){return null==e?0:e.getBoundingClientRect().left+p()}function S(e){return r.Browser.IE?function(e){if(null==e||r.Browser.IE&&null==e.parentNode)return 0;return e.getBoundingClientRect().top+g()}(e):r.Browser.Firefox&&r.Browser.Version>=3||r.Browser.WebKitFamily||r.Browser.Edge?B(e):getAbsolutePositionY_Other(e)}function B(e){return null==e?0:e.getBoundingClientRect().top+g()}function C(e,t,n){return e-=N(t,n)}function I(e,t){var n=function(e){var t=document.createElement("DIV");return t.style.top="0px",t.style.left="0px",t.visibility="hidden",t.style.position=D(e).position,t}(e);"static"==n.style.position&&(n.style.position="absolute"),e.parentNode.appendChild(n);var r=t?y(n):w(n);return e.parentNode.removeChild(n),r}function N(e,t){return I(e,t)}function T(e,t){try{var n,r=x(e);if(!r){var o=F(e);if(!o)return!1;n=o.split(" ")}for(var i=t.split(" "),u=i.length-1;u>=0;u--)if(r){if(-1===r.indexOf(i[u]))return!1}else if(Data.ArrayIndexOf(n,i[u])<0)return!1;return!0}catch(e){return!1}}function x(e){return e.classList?[].slice.call(e.classList):F(e).replace(/^\s+|\s+$/g,"").split(/\s+/)}function F(e){return"svg"===e.tagName?e.className.baseVal:e.className}function P(e,t){"svg"===e.tagName?e.className.baseVal=o(t):e.className=o(t)}function W(e,t){var n=t.toUpperCase(),o=null;return e&&(e.getElementsByTagName?0===(o=e.getElementsByTagName(n)).length&&(o=e.getElementsByTagName(t)):e.all&&void 0!==e.all.tags&&(o=r.Browser.Netscape?e.all.tags[n]:e.all.tags(n))),o}function O(e,t,n){return null!=e?function(e,t){return t||(t=0),null!=e&&e.length>t?e[t]:null}(W(e,t),n):null}function D(e){if(document.defaultView&&document.defaultView.getComputedStyle){var t=document.defaultView.getComputedStyle(e,null);if(!t&&r.Browser.Firefox&&window.frameElement){for(var n=[],o=window.frameElement;!(t=document.defaultView.getComputedStyle(e,null));)n.push([o,o.style.display]),_(o,"display","block",!0),o="BODY"==o.tagName?o.ownerDocument.defaultView.frameElement:o.parentNode;t=h(t);for(var i,u=0;i=n[u];u++)_(i[0],"display",i[1])}return r.Browser.Firefox&&r.Browser.MajorVersion>=62&&window.frameElement&&0===t.length&&((t=h(t)).display=e.style.display),t}return window.getComputedStyle(e,null)}function A(e){if(!e.createStyleSheet){var t=e.createElement("STYLE");return O(e,"HEAD",0).appendChild(t),t.sheet}try{return e.createStyleSheet()}catch(e){throw new Error("The CSS link limit (31) has been exceeded. Please enable CSS merging or reduce the number of CSS files on the page. For details, see http://www.devexpress.com/Support/Center/p/K18487.aspx.")}}var L=null;function _(e,t,n,r){if(r){var o=t.search("[A-Z]");-1!=o&&(t=t.replace(t.charAt(o),"-"+t.charAt(o).toLowerCase())),e.style.setProperty?e.style.setProperty(t,n,"important"):e.style.cssText+=";"+t+":"+n+"!important"}else e.style[t]=n}function G(e){"string"==typeof e&&(e=document.querySelector(e)),e&&e.focus()}function V(e,t,n){e&&(e[t]=n)}function M(e,t){e&&(e.indeterminate=t)}function j(e){return e.preventDefault?e.preventDefault():e.returnValue=!1,!1}function R(e){if(!e)return null;var t=null;if("string"==typeof e){var n=JSON.parse(e);n&&n.__internalId&&(t=n.__internalId)}(!t&&e.__internalId&&(t=e.__internalId),t)&&(e=document.querySelector("["+("_bl_"+t)+"]"));return e.tagName&&null!==e.parentNode||(e=null),e}function q(e,t,n){(e=R(e))&&V(e,t,n)}function H(e,t){e.removeAttribute?e.removeAttribute(t):e.removeProperty&&e.removeProperty(t)}function Y(e,t,n){n?V(e,t,n):H(e,t)}function K(e,t){return U(e,t)+$(e,t)}function k(e,t){return z(e,t)+X(e,t)}function U(e,t){var n=t||D(e);return parseInt(n.paddingLeft)+parseInt(n.paddingRight)}function z(e,t){var n=t||D(e);return parseInt(n.paddingTop)+parseInt(n.paddingBottom)}function X(e,t){t||(t=r.Browser.IE&&9!==r.Browser.MajorVersion&&window.getComputedStyle?window.getComputedStyle(e):D(e));var n=0;return"none"!==t.borderTopStyle&&(n+=parseFloat(t.borderTopWidth),r.Browser.IE&&r.Browser.MajorVersion<9&&(n+=getIe8BorderWidthFromText(t.borderTopWidth))),"none"!==t.borderBottomStyle&&(n+=parseFloat(t.borderBottomWidth),r.Browser.IE&&r.Browser.MajorVersion<9&&(n+=getIe8BorderWidthFromText(t.borderBottomWidth))),n}function $(e,t){t||(t=r.Browser.IE&&window.getComputedStyle?window.getComputedStyle(e):D(e));var n=0;return"none"!==t.borderLeftStyle&&(n+=parseFloat(t.borderLeftWidth),r.Browser.IE&&r.Browser.MajorVersion<9&&(n+=getIe8BorderWidthFromText(t.borderLeftWidth))),"none"!==t.borderRightStyle&&(n+=parseFloat(t.borderRightWidth),r.Browser.IE&&r.Browser.MajorVersion<9&&(n+=getIe8BorderWidthFromText(t.borderRightWidth))),n}var J=window.requestAnimationFrame||function(e){e()},Q=window.cancelAnimationFrame||function(e){};function Z(e){return J(e)}var ee=function(e){this.requestFrame=e,this.cache=[[]],this.isInFrame=!1,this.frameTimestamp=null,this.isWaiting=!1,this.getBuffer=function(e){return e||(e=0),this.cache.length<=e&&(this.cache[e]=[]),this.cache[e]},this.execute=function(e,t){if(!this.isInFrame)return!1;var n=this.cache[t||0];return null===n?e(te,this.frameTimestamp):(n=this.getBuffer(t)).push(e),!0},this.runAll=function(e){this.isWaiting=!1,this.isInFrame=!0,this.frameTimestamp=e;for(var t=0;t<this.cache.length;t++){var n=this.cache[t];if(n)for(this.cache[t]=null;n.length;)n.shift()(te,this.frameTimestamp)}this.waitNextFrame()},this.waitNextFrame=function(){this.cache=[[]],this.isInFrame=!1,this.isWaiting=!1},this.requestExecution=function(e,t){var n=this;return new Promise((function(r){function o(t,n){r(e(t,n))}n.execute(o,t)||(n.getBuffer(t).push(o),!1===n.isWaiting&&(n.isWaiting=!0,n.requestFrame(n.runAll.bind(n))))}))}},te=null;function ne(e){var t=new ee(e);return t.requestExecution.bind(t)}var re=ne((function(e){return te=Z(e)})),oe=ne((function(e){return re((function(){setTimeout(e)}))}));function ie(e){return re(e)}function ue(e){return oe(e)}var le=[];function se(e){0===le.length?(le.push(e),ue(ae)):le.push(e)}function ae(){(le=le.filter((function(e){return e()}))).length>0&&setTimeout((function(){ue(ae)}),50)}function ce(e,t){var n=[];for(var r in t)t.hasOwnProperty(r)&&n.push({attr:r,value:t[r]});if(1===n.length)e.style[n[0].attr]=n[0].value;else{var o="";if(e.style.cssText)for(var i=e.style.cssText.split(";").map((function(e){return e.trim().split(":")})),u=0;u<i.length;u++){var l=i[u];2===l.length&&void 0===t[l[0]]&&(o+=l[0]+":"+l[1].trim()+";")}for(u=0;u<n.length;u++){var s=n[u];""!==s.value&&(o+=s.attr+":"+s.value+";")}Y(e,"style",o)}}function de(e,t){for(var n in null===t.inlineStyles?H(e,"style"):ce(e,t.inlineStyles),t.attributes)t.attributes.hasOwnProperty(n)&&Y(e,n,t.attributes[n]);var r=x(t);if(r){var o=t.cssClassToggleInfo,i=r.filter((function(e){return!1!==o[e]}));for(var u in o)o.hasOwnProperty(u)&&o[u]&&-1===i.indexOf(u)&&i.push(u);var l=i.join(" ");l?P(e,l):H(e,"class")}}function fe(e){return{inlineStyles:{},cssClassToggleInfo:{},className:F(e),attributes:{}}}function me(e,t){if(void 0===e.length){var n=e;n._dxCurrentFrameElementStateInfo?t(n._dxCurrentFrameElementStateInfo):(t(n._dxCurrentFrameElementStateInfo=fe(n)),ie((function(){de(n,n._dxCurrentFrameElementStateInfo),n._dxCurrentFrameElementStateInfo=null})))}else for(var r=0;r<e.length;r++)me(e[r],t)}function he(e,t){var n=0;if(null!=e&&""!=e)try{var r=e.indexOf("px");r>-1&&(n=t(e.substr(0,r)))}catch(e){}return n}var pe={FocusElement:G,SetInputAttribute:q,SetCheckInputIndeterminate:M};n.AddClassNameToElement=function(e,t){if(e&&"string"==typeof t&&!T(e,t=t.trim())&&""!==t){var n=F(e);P(e,""===n?t:n+" "+t)}},n.AttachEventToElement=function(e,t,n,r,o){e.addEventListener?e.addEventListener(t,n,{capture:!r,passive:!!o}):e.attachEvent("on"+t,n)},n.CancelAnimationFrame=function(e){Q(e)},n.CloneObject=h,n.CreateStyleSheetInDocument=A,n.DetachEventFromElement=function(e,t,n){e.removeEventListener?e.removeEventListener(t,n,!0):e.detachEvent("on"+t,n)},n.ElementHasCssClass=T,n.EnsureElement=R,n.EraseBlazorIdentificators=function e(t){if(t.attributes)for(var n=0;n<t.attributes.length;n++){var r=t.attributes[n].name;(r.startsWith("_bl_")||r.startsWith("id"))&&t.removeAttribute(r)}t.childNodes.forEach((function(t){e(t)}))},n.FocusElement=G,n.GetAbsolutePositionX=b,n.GetAbsolutePositionY=S,n.GetAbsoluteX=y,n.GetAbsoluteY=w,n.GetClassName=F,n.GetClassNameList=x,n.GetCurrentStyle=D,n.GetCurrentStyleSheet=function(){return L||(L=A(document)),L},n.GetDocumentClientHeight=function(){return r.Browser.Firefox&&window.innerHeight-document.documentElement.clientHeight>v()?window.innerHeight:r.Browser.Opera&&r.Browser.Version<9.6||0==document.documentElement.clientHeight?document.body.clientHeight:document.documentElement.clientHeight},n.GetDocumentClientWidth=function(){return 0==document.documentElement.clientWidth?document.body.clientWidth:document.documentElement.clientWidth},n.GetDocumentScrollLeft=p,n.GetDocumentScrollTop=g,n.GetHorizontalBordersWidth=$,n.GetLeftRightBordersAndPaddingsSummaryValue=K,n.GetLeftRightPaddings=U,n.GetNearestPositionedParent=function(e,t){void 0===t&&(t=!1);for(var n=t?e:e.parentNode;n&&"static"==window.getComputedStyle(n).position;)n=n.parentNode;return n},n.GetNodeByTagName=O,n.GetNodesByTagName=W,n.GetParentByClassName=function(e,t){return function(e,t,n){for(;null!=e;){if("BODY"==e.tagName||"#document"==e.nodeName)return null;if(n(e,t))return e;e=e.parentNode}return null}(e,t,T)},n.GetPositionElementOffset=N,n.GetTopBottomBordersAndPaddingsSummaryValue=k,n.GetTopBottomPaddings=z,n.GetVerticalBordersWidth=X,n.GetVerticalScrollBarWidth=v,n.Log=function(e){},n.PrepareClientPosForElement=C,n.PreventEvent=j,n.PreventEventAndBubble=function(e){return j(e),e.stopPropagation&&e.stopPropagation(),e.cancelBubble=!0,!1},n.PxToFloat=function(e){return he(e,parseFloat)},n.PxToInt=function(e){return he(e,parseInt)},n.QuerySelectorFromRoot=function(e,t){e.dataset.tempUniqueId="tempUniqueId";try{t("[data-temp-unique-id]")}catch(e){}finally{delete e.dataset.tempUniqueId}},n.RemoveClassNameFromElement=function(e,t){if(e){var n=" "+F(e)+" ",r=n.replace(" "+t+" "," ");n.length!=r.length&&P(e,o(r))}},n.RequestAnimationFrame=Z,n.RetrieveByPredicate=function(e,t){for(var n=[],r=0;r<e.length;r++){var o=e[r];t&&!t(o)||n.push(o)}return n},n.SetAbsoluteX=function(e,t){e.style.left=C(t,e,!0)+"px"},n.SetAbsoluteY=function(e,t){e.style.top=C(t,e,!1)+"px"},n.SetAttribute=V,n.SetCheckInputIndeterminate=M,n.SetClassName=P,n.SetInputAttribute=q,n.SetStylesCore=_,n.applyStateToElement=de,n.applyStyles=ce,n.calculateStyles=ue,n.changeDom=ie,n.clearStyles=function(e){me(e,(function(e){e.inlineStyles=null,e.cssClassToggleInfo["visually-hidden"]=!1}))},n.createElementState=fe,n.domUtils=pe,n.elementIsInDOM=function(e){return document.body.contains(e)},n.findParentBySelector=function(e,t){if(!e)return null;if(e.closest)return e.closest(t);do{if((e.matches||e.msMatchesSelector).call(e,t))return e;e=e.parentElement||e.parentNode}while(e&&"BODY"!==e.tagName);return null},n.getDocumentScrollLeft=function(){return r.Browser.Edge?document.body?document.body.scrollLeft:document.documentElement.scrollLeft:r.Browser.WebKitFamily?document.documentElement.scrollLeft||document.body.scrollLeft:document.documentElement.scrollLeft},n.getDocumentScrollTop=function(){return r.Browser.WebKitFamily||r.Browser.Edge?r.Browser.MacOSMobilePlatform?window.pageYOffset:r.Browser.WebKitFamily&&document.documentElement.scrollTop||document.body.scrollTop:document.documentElement.scrollTop},n.getEventSource=function(e){return e&&(e.srcElement||e.target)},n.nextChangeDOM=function(e){ie(e)},n.setCssClassName=function(e,t){me(e,(function(e){e.cssClassToggleInfo={},e.className=t}))},n.setStyles=function(e,t){me(e,(function(e){if(null===e.inlineStyles)e.inlineStyles=t;else for(var n in t)t.hasOwnProperty(n)&&(e.inlineStyles[n]=t[n])}))},n.subscribeElementContentSize=function(e,t){var n=function(e,t,n){return function(){if(e.compareDocumentPosition(document.body)&Node.DOCUMENT_POSITION_DISCONNECTED)return!1;var r=D(e);if("auto"===r.width)return!0;var o=parseInt(r.width)-K(e),i=parseInt(r.height)-k(e);return n.width===o&&n.height===i||(n.width=o,n.height=i,t(n)),!0}}(e,t,{width:-1,height:-1});return se(n),n},n.subscribeElementContentWidth=function(e,t){var n=function(e,t,n){return function(){if(e.compareDocumentPosition(document.body)&Node.DOCUMENT_POSITION_DISCONNECTED)return!1;var r=D(e);if("auto"===r.width)return!0;var o=parseInt(r.width)-K(e);return n!==o&&t(n=o),!0}}(e,t,-1);return se(n),n},n.subscribeElementDisconnected=function(e,t){se(function(e,t){return function(){return!(e.compareDocumentPosition(document.body)&Node.DOCUMENT_POSITION_DISCONNECTED)||(t(),!1)}}(e,t))},n.toggleCssClass=function(e,t,n){me(e,(function(e){e.cssClassToggleInfo[t]=n}))},n.unsubscribeElement=function(e){le.splice(le.indexOf(e),1)},n.updateAttribute=function(e,t,n){me(e,(function(e){e.attributes[t]=n}))},n.updateElementState=me,n.whenDeleted=function(e){if(s.has(e))return s.get(e);var t=new Promise((function(t){0===a.size&&d.observe(l,c);a.set(e,(function(){e=null,t()}))}));return s.set(e,t),t}}),["cjs-chunk-9eab2df8.js"]);