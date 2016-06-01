using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Reflection;

namespace reflectionDemoGUI
{
    public partial class reflection : UserControl
    {
        #region events
        public delegate void targetMethod(MethodInfo targetMethod, TreeNode TN);
        public event targetMethod selectedMethod;

        public delegate void targetConstructor(ConstructorInfo targetConstructor, TreeNode TN);
        public event targetConstructor selectedConstructor;

        public reflection()
        {
            InitializeComponent();
            refreshDomain_BT.Text = System.AppDomain.CurrentDomain.FriendlyName;
        }

        void hierarchyViewer_selectedMethod(MethodInfo targetMethod, TreeNode TN)
        {
        }

        void hierarchyViewer_selectedConstructor(ConstructorInfo targetConstructor, TreeNode TN)
        {
        }

        private void refreshDomain_BT_Click(object sender, EventArgs e)
        {
            domainAssemblies.Clear();
            domainClasses.Clear();
            methods.Clear();
            constructors.Clear();
            hierarchyViewer_TN.Nodes.Clear();
            buildTree();
        }
        #endregion events

        #region init
        public void loadhierarchyViewer()
        {
            selectedMethod += hierarchyViewer_selectedMethod;
            selectedConstructor += hierarchyViewer_selectedConstructor;
            buildTree();
        }
        #endregion init

        #region treeNode
        System.Collections.Generic.Dictionary<TreeNode, Assembly> domainAssemblies = new Dictionary<TreeNode, Assembly>();
        System.Collections.Generic.Dictionary<TreeNode, Type> domainClasses = new Dictionary<TreeNode, Type>();
        System.Collections.Generic.Dictionary<TreeNode, MethodInfo> methods = new Dictionary<TreeNode, MethodInfo>();
        System.Collections.Generic.Dictionary<TreeNode, ConstructorInfo> constructors = new Dictionary<TreeNode, ConstructorInfo>();

        public void buildTree()
        {
            AppDomain myDomain = AppDomain.CurrentDomain;
            Assembly[] allAssemblies = myDomain.GetAssemblies();

            foreach (Assembly asm in allAssemblies)
            {
                string assemblyName = asm.FullName.ToString();
                System.Windows.Forms.TreeNode Assemblies = new TreeNode(assemblyName.ToString());
                domainAssemblies.Add(Assemblies, asm);
                hierarchyViewer_TN.Nodes.Add(Assemblies);
            }
            hierarchyViewer_TN.Sort();
        }

        private void hierarchyViewer_TN_AfterSelect(object sender, TreeViewEventArgs e)
        {
            TreeNode theSelectedNode = hierarchyViewer_TN.SelectedNode;

            if (theSelectedNode != null)
            {
                if (domainAssemblies.ContainsKey(theSelectedNode))
                {
                    Assembly assemblySelected = domainAssemblies[theSelectedNode];

                    Type[] types = assemblySelected.GetTypes();
                    foreach (Type type in types)
                    {
                        System.Windows.Forms.TreeNode asmClass = new TreeNode(type.ToString());
                        domainClasses.Add(asmClass, type);
                        theSelectedNode.Nodes.Add(asmClass);
                        makeMethodandFunctionList(asmClass, theSelectedNode);
                        domainAssemblies.Remove(theSelectedNode);
                    }
                    hierarchyViewer_TN.Sort();
                }
                else if (methods.ContainsKey(theSelectedNode))
                {
                    MethodInfo methodSelected = methods[theSelectedNode];

                    if (selectedMethod != null && methodSelected != null)
                        selectedMethod(methodSelected, theSelectedNode);
                }
                else if (constructors.ContainsKey(theSelectedNode))
                {
                    ConstructorInfo constructorSelected = constructors[theSelectedNode];

                    Assembly assemblySelected = domainAssemblies[theSelectedNode.Parent.Parent];

                    if (selectedConstructor != null && constructorSelected != null)
                        selectedConstructor(constructorSelected, theSelectedNode);
                }
            }
        }

        private void makeMethodandFunctionList(TreeNode parent, TreeNode theSelectedNode)
        {
            try
            {
                var classSelected = domainClasses[parent];

                MethodInfo[] methodInfo = classSelected.GetMethods(BindingFlags.NonPublic | BindingFlags.Static | BindingFlags.Instance | BindingFlags.Public | BindingFlags.DeclaredOnly);
                ConstructorInfo[] constructorList = classSelected.GetConstructors(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);

                foreach (ConstructorInfo constructorInfo in constructorList)
                {
                    object fullConType = constructorInfo as object;
                    object item = null;
                    System.Windows.Forms.TreeNode asmMethod = new TreeNode(fullConType.ToString());
                    parent.Nodes.Add(asmMethod);
                    constructors.Add(asmMethod, constructorInfo);
                    if (constructorInfo.GetParameters().Length == 0)
                    {
                        try
                        {
                            item = constructorInfo.Invoke(new object[] { });
                        }
                        catch (SystemException) { continue; }
                        System.Windows.Forms.TreeNode fields = new TreeNode("fields");
                        System.Windows.Forms.TreeNode properties = new TreeNode("properties");

                        PropertyInfo[] propInfos = item.GetType().GetProperties(BindingFlags.Static | BindingFlags.Public | BindingFlags.Instance | BindingFlags.NonPublic);
                        FieldInfo[] fieldInfo = item.GetType().GetFields(BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);

                        foreach (PropertyInfo property in propInfos)
                        {
                            try
                            {

                                fields.Nodes.Add(property.ToString());
                            }
                            catch { continue; }
                        }
                        foreach (FieldInfo field in fieldInfo)
                        {
                            try
                            {
                                properties.Nodes.Add(field.ToString());
                            }
                            catch { continue; }
                        }

                        parent.Nodes.Add(fields);
                        parent.Nodes.Add(properties);
                    }
                }

                foreach (MethodInfo classMethods in methodInfo)
                {
                    System.Windows.Forms.TreeNode asmMethod = new TreeNode(classMethods.Name);
                    parent.Nodes.Add(asmMethod);
                    methods.Add(asmMethod, classMethods);

                }
            }
            catch { }
        }
        #endregion

        #region GUIEvents
        private void refreshDomain_BT_Click_1(object sender, EventArgs e)
        {

            domainAssemblies.Clear();
            domainClasses.Clear();
            methods.Clear();
            constructors.Clear();
            hierarchyViewer_TN.Nodes.Clear();
            buildTree();
        }

        private void hierarchyViewer_TN_AfterSelect_1(object sender, TreeViewEventArgs e)
        {
            try
            {
                TreeNode theSelectedNode = hierarchyViewer_TN.SelectedNode;

                if (theSelectedNode != null)
                {
                    if (domainAssemblies.ContainsKey(theSelectedNode))
                    {
                        Assembly assemblySelected = domainAssemblies[theSelectedNode];

                        Type[] types = assemblySelected.GetTypes();
                        foreach (Type type in types)
                        {
                            System.Windows.Forms.TreeNode asmClass = new TreeNode(type.ToString());
                            domainClasses.Add(asmClass, type);
                            theSelectedNode.Nodes.Add(asmClass);
                            makeMethodandFunctionList(asmClass, theSelectedNode);
                            domainAssemblies.Remove(theSelectedNode);
                        }
                        hierarchyViewer_TN.Sort();
                    }
                    else if (methods.ContainsKey(theSelectedNode))
                    {
                        MethodInfo methodSelected = methods[theSelectedNode];

                        if (selectedMethod != null && methodSelected != null)
                            selectedMethod(methodSelected, theSelectedNode);
                    }
                    else if (constructors.ContainsKey(theSelectedNode))
                    {
                        ConstructorInfo constructorSelected = constructors[theSelectedNode];

                        Assembly assemblySelected = domainAssemblies[theSelectedNode.Parent.Parent];

                        if (selectedConstructor != null && constructorSelected != null)
                            selectedConstructor(constructorSelected, theSelectedNode);
                    }
                }
            }
            catch { }
        }
        #endregion
    }
}







