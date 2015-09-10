
/**在指定DOM节点中添加一个Label
 * @param node 指定的DOM节点
 * @param labelName Label的id值
 */
    function InsertLabel(node,labelName)
    {
        var label=document.createElement("label");
        label.innerHTML=labelName+":";
        node.appendChild(label);
    }
    
    /**指定DOM节点中插入一个文本框
     * @param node 指定的DOM节点
     * @param indicator 文本框的name值 
    */
    function InsertTextBox(node,indicator){//
        var text=document.createElement("input");
        text.type="text";
        text.setAttribute("name",indicator);
        node.appendChild(text);
    }

    /**在指定DOM节点中插入一个复选框
     * @param node
     * @param id
     * @param tdid
     * @param innerText
     * @constructor
     */
    function InsertCheckedBox(node,id,tdid,innerText){
        //<input type="checkbox">
        var check=document.createElement("input");
        check.type="checkbox";
        check.setAttribute("name",tdid+"_"+id);
        check.value=innerText;
        node.appendChild(check);
    }

    /**插入文本框
     * @param node
     * @param labelName
     * @param indicator
     */
    function InsertTxtInput(node,labelName,indicator){
        InsertLabel(node,labelName);
        InsertTextBox(node,indicator);
    }

    //+鎸夐挳锛氬湪鈥滆缃壒寰佸�鈥濋潰鏉夸笂娣诲姞鐢ㄤ簬杈撳叆鐗瑰緛鍊肩殑鏂囨湰妗嗐�
    var id=1;
    function addvalue(){
        id++;
        var fid=$("#fid")[0];
        var htmlText=fid.innerHTML;
        fid.innerHTML=htmlText+id+"<br>";
        var td=document.getElementById("val");
        InsertTextBox(td,"*",id);

    }

    //【这是特征函数的值的面板中减去一个特征值】
    function removevalue(){
        if(id==0){
            return;
        }
        $("#val input:last").remove();
        var fid=$("#fid")[0];
        var htmlText=fid.innerHTML;
        var lastnum=htmlText.lastIndexOf("<br>",htmlText.length-5);
        var subhtml="";
        if(lastnum>=0){
            subhtml=htmlText.substring(0,lastnum+4);
        }
        fid.innerHTML=subhtml;
        id--;
    }

    //璁剧疆鐗瑰緛鍊尖�闈㈡澘涓婄殑鈥滃彇娑堚�鎸夐挳
    function cancel(){
        $("#eigenfunctionDesign").css("visibility","hidden");
    }

    //鈥滆缃壒寰佸�鈥濋潰鏉夸笂鐨勨�纭鈥濇寜閽�
    var td;
    function confirm(){
        var index=1;
        var inputs=$("#val input");
        inputs.each(function(item){
            var node=inputs[item];
            InsertCheckedBox(td,index++,td.id,node.value);
            td.innerHTML+=node.value;
        });
        cancel();
    }

    
    
    /**限制条件中改变数据的类型
     * @param node 被改变的checkbox
     * @param tdid 该checkbox所在的单元格的前一个单元格的id
     */
    function changeDataType(node,tdid){
    	require(["dojo/dom-attr","dojo/domReady!"],
    	   	function(attr){
    		var dataType=attr.get(node,"value");
    		var reg=/(\w+)limitativecondition/;
    		var name=tdid.match(reg);
    		 switch (dataType){
    		 case "numeric":
    			 attr.set(tdid,"innerHTML","<select name='relation'>"
			                        +"<option value='more'> &gt;</option>"
			                        +"<option value='less'>&lt;</option>"
			                        +"<option value='equal' selected='selected'>=</option>"
			                 +"</select><input type='text' name='"+name[1]+"' value=''/>");
    			 break;
    		 case "notnumeric":
    			 attr.set(tdid,"innerHTML","<select name='relation'>"
	                        +"<option value='in' selected='selected'>in</option>"
	                 +"</select><input type='text' name='"+name[1]+"' value=''/>");
    			 break;
    		 }
    	});
    }

   var suitaLevel=null;
   require(["dojo/on","model/changeDisplay","model/textbox","dojo/dom-form",
      "dojo/query","dojo/dom-attr","dojo/request","dojo/json","dojo/dom-style","dojo/domReady!"],
	function(on,changeDisplay,textbox,domForm,query,attr,request,json,style){
	 
	 var textBox=new textbox();
	 textBox.registerChangeEvent(".SutiaPDJZ");
	 
	 
	 /**水土保持措施适宜性分级规则入库
	  */
	 on(dojo.byId("form_syxLevel"),"submit",function(evt){
		 evt.stopPropagation();
         evt.preventDefault();
         var formId="form_syxLevel";
         var dataJson=domForm.toObject(formId);
         alert(dataJson.levelLabel);
         suitaLevel=dataJson.levelLabel;
         //设置适宜性分级规则的id
         dataJson.categoryid=3;
         request.post(
 				getRootPath()+"/syxpj/syxjb.action",{
 					data:dataJson
 				}).then(function(response){
 					alert("OK");
 					//alert(response);
 					alert(getRootPath()+"/syxpj/syxjb.action");
 				},function(error){
 					alert(error);
 				});
	 });
	
	/**提交效益性指标判断矩阵，计算权重
	 */
	on(dojo.byId("benefitFactorsform"),"submit",function(evt){
		evt.stopPropagation();
        evt.preventDefault();
        
        var formId="benefitFactorsform";
        var dataJson=domForm.toObject(formId); 
		dataJson.target=formId.substring(0,formId.indexOf("form"));

		request.post(
        		getRootPath()+"/weight/suitaW.action",{
        			data:dataJson
        		}).then(function(response){
        			if(response.indexOf("判断矩阵未通过一致性检验")>=0){
        				alert("msg:"+response);
        			}else{
        				var weight=json.parse(response);
    					for(var x in weight){
    						style.set(dojo.byId(x),"display","inline");
    						attr.set(x,"value",weight[x]);
    					}
        			}	
				},function(error){
					alert("err:"+error);
				});
	});
	
	/**提交适宜性指标判断矩阵，计算权重
	 */
	on(dojo.byId("suitabilityFactorsform"),"submit",function(evt){
		evt.stopPropagation();
        evt.preventDefault();
        var formId="suitabilityFactorsform";
        var dataJson=domForm.toObject(formId);
		dataJson.target=formId.substring(0,formId.indexOf("form"));		
        
		request.post(
				getRootPath()+"/weight/suitaW.action",{
        			data:dataJson
        		}).then(function(response){
					var weight=json.parse(response);
					for(var x in weight){
						style.set(dojo.byId(x),"display","inline");
						attr.set(x,"value",weight[x]);
					}
				},function(error){
					alert(error);
				});
	});
	
	/**在适宜性权重计算成功后，进行的适宜性指标权重规则入库。
	 */
	on(dojo.byId("suitabilityFactorscreateRule"),"click",function(){
		request.post(
				getRootPath()+"/weight/createRule.action?target=suitabilityFactors&categoryid=4"
				).then(function(response){
					alert(ok);
				},
				function(error){
					alert(error);
				});
	});
	
	/**在效益性权重计算成功后，进行的效益指标权重规则入库。
	 */
	on(dojo.byId("benefitFactorscreateRule"),"click",function(){
		request.post(
				getRootPath()+"/weight/createBenefitRule.action?target=benefitFactors&categoryid=1"
				).then(function(response){
			alert("OK");
		},function(error){
			alert(error);
		});   	
	});
	
	/**模糊函数构建规则提交入库
	 */
	on(dojo.byId("modelCreatedRule"),"submit",function(evt){
		 evt.stopPropagation();
         evt.preventDefault();
         var formId="modelCreatedRule";
         var dataJson=domForm.toObject(formId);
         //设置适宜性分级规则的id
      //   dataJson.categoryid=3;
		request.post(getRootPath()+"/syxpj/MHFunction.action?categoryid=2",{
			data:dataJson
		}).then(function(response){		
		},function(error){
			alert(error);
			});
	});
	
	/**限制性条件规则入库
	 */
	on(dojo.byId("limitativeRuleform"),"submit",function(evt){
		dojo.stopEvent(evt);
		var formId="limitativeRuleform";
		var dataJson=domForm.toObject(formId);
		request.post(getRootPath()+"/syxpj/restrictiveCondition.action?categoryid=5",{
			data:dataJson
		}).then(function(response){
			alert("保存成功!!!");
		},function(error){alert(error);});
	});
	
	/**计算模型选择规则入库
	 */
	on(dojo.byId("selCompModel"),"submit",function(evt){
		dojo.stopEvent(evt);
		var formId="selCompModel";
		var dataJson=domForm.toObject(formId);
		request.post(getRootPath()+"/syxpj/selCompModel.action?categoryid=6",{
			data:dataJson
		}).then(function(response){
			alert("保存成功!!!");
		},function(error){alert(error);});
	});
});
 
 //模糊函数拐点设计  
 function selected(ambiguousFun,indicator){
 	require(["dojo/on","model/changeDisplay","model/textbox","model/Form",
 	         "dojo/query","dojo/dom-attr","dojo/request","dojo/domReady!"],
 	   	function(on,changeDisplay,textbox,Form,query,attr,request){

       var ambiguousFun1= attr.get(ambiguousFun,"value");//获取选择框中选择的值.
       //attr.set(indicator,"innerHTML","");
       td=document.getElementById(indicator);
       td.innerHTML="";
       switch (ambiguousFun1){
           case "upper":
               labelName=["a","b"];
               for(var i=0; i<2; i++){
                   InsertTxtInput(td,labelName[i],indicator);//
               }
               break;
           case "down":
               labelName=["a","b"];
               for(var i=0; i<2; i++){
                   InsertTxtInput(td,labelName[i],indicator);//
               }
               break;
           case "parabola":
               labelName=["a1","b1","b2","a2"];
               for(var i=0; i<4; i++){
                   InsertTxtInput(td,labelName[i],indicator);
               }
               break;
           case "eigenfunction":
           	if(suitaLevel==null){
           		request.post().then(function(response){
           			suitaLevel=response;
           		},function(error){alert(errot);});
           	}
           	var innerhtml="";
           	suitaLevel.forEach(function(node){
           		innerhtml+="<span>"+node+":</span>"+"<input type='text' name='"+indicator+"' value=''/>";
           	});
           	attr.set(indicator,"innerHTML",innerhtml);
               break;
       }
 	});
 }
