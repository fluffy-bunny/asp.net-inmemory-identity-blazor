DxBlazorInternal.define("cjs-chunk-8f910901.js",(function(e,t,n){var i=e("./cjs-chunk-f9f4d45f.js"),o=function(e){this.eventTokens=[],this.context=e};o.prototype.AttachEventWithContext=function(e,t,n,o){if(!this.eventTokens||!o||!e)return{item:null,name:null,delegate:null,Dispose:function(){}};var s=this,u=n.bind(o);i.AttachEventToElement(e,t,u);var l={item:e,name:t,delegate:u,Dispose:function(){s.DetachEvent(this)}};return this.eventTokens.push(l),l},o.prototype.AttachEvent=function(e,t,n){return this.AttachEventWithContext(e,t,n,this.context)},o.prototype.DetachEvent=function(e){if(!this.eventTokens)return null;if(!e||!e.item)return!1;var t=this.eventTokens.indexOf(e);return!!(t&&t>0)&&(i.DetachEventFromElement(e.item,e.name,e.delegate),this.eventTokens.splice(t,1),e.item=null,e.delegate=null,e.Dispose=function(){},!0)},o.prototype.Dispose=function(){return!!this.eventTokens&&(this.eventTokens.forEach((function(e){e.item&&(i.DetachEventFromElement(e.item,e.name,e.delegate),e.item=null,e.delegate=null,e.Dispose=function(){})})),this.eventTokens=null,!0)},n.EventRegister=o}),["cjs-chunk-f9f4d45f.js"]);