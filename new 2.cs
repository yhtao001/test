		[9]
		"安徽,31112"
		string
		    [44]
		"六安,1971"
		string

		http: //192.168.11.101:60/Home/Index

		    浙江省杭州市西湖区文三路259号昌地火炬大厦1号楼605 程凤 18868750828

		if (!CheckIsAllSubmit ()) {
		    var nowYear = $("#
		    selYear ").val ();
                var nowMonth = $("#
		    selMont ").val ();
                showWarningMsg (nowYear + "
		    年 " + nowMonth + "
		    月, 还有暂未提交审核的数据!");
                //$('#Save').css("
		    display ", "
		    none ");
                //$('#Submit').css("
		    display ", "
		    none ");
                //return false;
            }
			
			dt.Select(" (ParentId = 'hjw006') || (ParentId = '0')
		    ");
			
			
            else if (requestValue != null && requestValue == "杭州望江门机务段二级部门 ")//不包括第三级部门，只到车间
            {
                StringBuilder sb = new StringBuilder();
                sb.Append(@"
		    SELECT Organization_ID, ParentId, Organization_Name FROM Base_Organization WHERE DeleteMark = 1 AND ParentId = 'HJW006'
		    OR ParentId = '0'
		    ORDER BY SortCode ");
                var dt2= DataFactory.SqlDataBase().GetDataTableBySQL(sb);

                if (DataTableHelper.IsExistRows(dt2))
                {
                    List<OrganizationModel> list = new List<OrganizationModel>();
                    foreach (DataRow row in dt2.Rows)
                    {
                        list.Add(new OrganizationModel()
                        {
                            id = row["
		    Organization_ID "].ToString(),
                            pId = row["
		    ParentId "].ToString(),
                            name = row["
		    Organization_Name "].ToString (),
                            open = true,
                            isParent = false
                        });
                    }

                    JavaScriptSerializer js = new JavaScriptSerializer ();
                    ZTree = js.Serialize (list);
                    return ZTree;
                }
            }