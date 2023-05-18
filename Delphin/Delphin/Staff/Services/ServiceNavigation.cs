using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using viewModels = Delphin.Pages.ViewModels;
using views = Delphin.Pages.Views;
using Xamarin.Forms;

using ConstantEnums = Delphin.Abstraction.Constants.ConstantEnum;
using constEnumClient = Delphin.Constants.ConstantEnum.EnumClientMobile;
using constantTextMessageCenter = Delphin.Abstraction.Constants.ConstantText.ClientMessageCenter;
using customControl = Delphin.Staff.Customs.Controls;
using services = Delphin.Staff.Services;


namespace Delphin.Staff.Services
{
    public class ServiceNavigation
    {
        static readonly Lazy<ServiceNavigation> LazyInstance = new Lazy<ServiceNavigation>(() => new ServiceNavigation(), true);
        public static ServiceNavigation Instance => LazyInstance.Value;

        readonly Dictionary<string, Type> _pageTypes;
        readonly Dictionary<string, Type> _viewModelTypes;

        public ServiceNavigation()
        {
            _pageTypes = GetAssemblyPageTypes();
            _viewModelTypes = GetAssemblyViewModelTypes();

            MessagingCenter.Subscribe<MessageBus, NavigationPushInfo>(this, constantTextMessageCenter.NavigationPushMessage, NavigationPushCallback);
            MessagingCenter.Subscribe<MessageBus, NavigationPopInfo>(this, constantTextMessageCenter.NavigationPopMessage, NavigationPopCallback);
        }



        #region Инициализация приложения

        public static Task Init(constEnumClient.Pages page,
            //constEnumClient.NavigationInitialize navigationInitialize = constEnumClient.NavigationInitialize.singlePage,
            Dictionary<string, object> NavParams = null)
        {
            return Instance.Initialize(page, NavParams);
        }

        Task Initialize(constEnumClient.Pages page,
            Dictionary<string, object> navParams)
        {
            var tks = new TaskCompletionSource<bool>();
            var initPage = GetInitializePage(page.ToString());
            //RootPush(initPage, tks);
            TabbedPush(initPage, tks);
            //MasterPush(initPage, tks);
            //SetMasterDetailPage(pageArray, navParams, tks);
            return tks.Task;

            //Action initializeFirstPage = () =>
            //{
            //    switch (initializeType)
            //    {
            //        case constEnumClient.NavigationInitialize.singlePage:
            //            SetMainPage(pageArray, navParams, hasNavigationBar);
            //            break;
            //        case constEnumClient.NavigationInitialize.tabbedPage:
            //            SetTabbedPage(pageArray, navParams, SelectedTabbedPage);
            //            break;
            //        case constEnumClient.NavigationInitialize.masterDetailPage:
            //            SetMasterDetailPage(pageArray, navParams);
            //            break;
            //        default:
            //            throw new NotImplementedException();
            //    }
            //};

            ////Device.BeginInvokeOnMainThread(initializeFirstPage);
            //initializeFirstPage.Invoke();
        }

        void NavigationPushCallback(MessageBus bus, NavigationPushInfo navigationPushInfo)
        {
            if (navigationPushInfo == null)
            {
                throw new ArgumentNullException(nameof(navigationPushInfo));
            }

            if (string.IsNullOrEmpty(navigationPushInfo.To))
            {
                throw new FieldAccessException(@"'To' page value should be set");
            }

            Push(navigationPushInfo);
        }

        void NavigationPopCallback(MessageBus bus, NavigationPopInfo navigationPopInfo)
        {
            if (navigationPopInfo == null)
            {
                throw new ArgumentNullException(nameof(navigationPopInfo));
            }

            Pop(navigationPopInfo);
        }

        #endregion

        #region Создание начальной страницы

        //public void SetMasterDetailPage(object[] pageArray,
        //    Dictionary<string, object> navParams,
        //    TaskCompletionSource<bool> tks
        //    )
        //{
        //    var initPage = GetInitializePage(pageArray.First().ToString(), navParams);
        //    MasterPush(initPage , tks);

        //}

        //public void SetMainPage(object[] pageArray,
        //    Dictionary<string, object> navParams,
        //    bool hasNavigationBar = false)
        //{
        //    var myPage = pageArray.First();
        //    var initPage = GetInitializePage(myPage.ToString(), navParams, hasNavigationBar);



        //    var navigationPage = new NavigationPage(initPage);


        //    Application.Current.MainPage = navigationPage;
        //}

        //public void SetTabbedPage(object[] pageArray, Dictionary<string, object> navParams, int SelectedTabbedPage, bool showNavigationBar = false)
        //{
        //    var tabbedPage = new TabbedPage();
        //    //var tabbedPage = new CustomControls.MagicTabbedPage();

        //    string pageString = string.Empty;

        //    foreach (object pageName in pageArray)
        //    {
        //        pageString = pageName.ToString();
        //        //var myPage = GetInitializePage(pageString, navParams, hasNavigationBar:false);
        //        var myPage = GetInitializePage(pageString, navParams);
        //        myPage.SetTitle(pageString);

        //        NavigationPage.SetHasNavigationBar(myPage, showNavigationBar);


        //        var myNavPage = new NavigationPage(myPage);

        //        //myNavPage.Popped += MyNavPage_Popped1;

        //        myNavPage.Title = pageString;
        //        //myNavPage.Popped += MyNavPage_Popped;

        //        //var result = ServiceImage.Instance.GetTabbedImage(0, false);

        //        //var embeddedImage = new Image { Source = ImageSource.FromResource(result.Data, NorbekovApp.Content.Data.GetAssembly()) };

        //        //myNavPage.IconImageSource = result.Data;

        //        tabbedPage.Children.Add(myNavPage);
        //    }

        //    tabbedPage.SelectedItem = tabbedPage.Children[SelectedTabbedPage];

        //    Device.BeginInvokeOnMainThread(() => { Application.Current.MainPage = tabbedPage; });

        //}






        #endregion


        #region Навигация туда-сюда








        INavigation GetTopNavigation(int index = 0)
        {
            var mainPage = Application.Current.MainPage;
            if (mainPage is MasterDetailPage masterDetailPage)
            {
                if (masterDetailPage.Detail is NavigationPage navigationPage)
                {
                    var modalStack = navigationPage.Navigation.ModalStack.OfType<NavigationPage>().ToList();
                    if (modalStack.Any())
                    {
                        return modalStack.LastOrDefault()?.Navigation;
                    }
                    return navigationPage.Navigation;
                }
            }
            else if (mainPage is TabbedPage navigationPage)
            {
                return navigationPage.Children[0].Navigation;
            }
            return (mainPage as NavigationPage)?.Navigation;
            //if (mainPage is TabbedPage tabbedPage)
            //{
            //    return tabbedPage.Children[selectedTab].Navigation;
            //}

            //return (mainPage as NavigationPage)?.Navigation;
        }

        void Push(NavigationPushInfo pushInfo)
        {
            int ActivTabIndex = pushInfo.ActivTabIndex;
            var newPage = GetInitializePage(pushInfo);

            switch (pushInfo.Mode)
            {
                case constEnumClient.NavigationMode.Normal:
                    NormalPush(newPage, pushInfo.OnCompletedTask);
                    break;
                case constEnumClient.NavigationMode.Modal:
                    ModalPush(newPage, pushInfo.OnCompletedTask, pushInfo.NewNavigationStack);
                    break;
                case constEnumClient.NavigationMode.RootPage:
                    RootPush(newPage, pushInfo.OnCompletedTask);
                    break;
                case constEnumClient.NavigationMode.Master:
                    MasterPush(newPage, pushInfo.OnCompletedTask);
                    break;
                case constEnumClient.NavigationMode.Tabbed:
                    TabbedPush(newPage, pushInfo.OnCompletedTask);
                    break;
                case constEnumClient.NavigationMode.TabbedChange:
                    TabbedChangePush(ActivTabIndex, newPage, pushInfo.OnCompletedTask);
                    break;
                case constEnumClient.NavigationMode.Custom:
                    CustomPush(newPage, pushInfo.OnCompletedTask);
                    break;
                default:
                    throw new NotImplementedException();
            }

        }





        void RootPush(Page newPage,
            TaskCompletionSource<bool> pushInfoOnCompletedTask)
        {
            Device.BeginInvokeOnMainThread(() =>
            {
                try
                {

                    Application.Current.MainPage = new NavigationPage(newPage);

                    pushInfoOnCompletedTask.SetResult(true);
                }
                catch
                {
                    pushInfoOnCompletedTask.SetResult(false);
                }
            });
        }

        void NormalPush(Page newPage,
            TaskCompletionSource<bool> completed
            )
        {
            Device.BeginInvokeOnMainThread(async () =>
            {
                try
                {
                    await GetTopNavigation().PushAsync(newPage, true);
                    completed.SetResult(true);
                }
                catch
                {
                    completed.SetResult(false);
                }
            });
        }

        void ModalPush(Page newPage, TaskCompletionSource<bool> completed, bool newNavigationStack = true)
        {
            Device.BeginInvokeOnMainThread(async () =>
            {
                try
                {
                    if (newNavigationStack)
                    {
                        newPage = new NavigationPage(newPage);
                    }
                    await GetTopNavigation().PushModalAsync(newPage, true);
                    completed.SetResult(true);
                }
                catch
                {
                    completed.SetResult(false);
                }
            });
        }

        void MasterPush(Page newPage, TaskCompletionSource<bool> pushInfoOnCompletedTask = null)
        {
            Device.BeginInvokeOnMainThread(async () =>
            {
                try
                {
                    if (Application.Current.MainPage is MasterDetailPage mp)
                    {
                        mp.IsPresented = false;
                        await Task.Delay(250);
                        if (mp.Detail is NavigationPage navigationPage)
                        {
                            var navigation = navigationPage.Navigation;
                            var navigationStack = navigationPage.Navigation.NavigationStack;
                            if (navigationStack.Any())
                            {
                                navigation.InsertPageBefore(newPage, navigationStack.FirstOrDefault());
                                await navigation.PopToRootAsync();
                            }
                        }
                        pushInfoOnCompletedTask?.SetResult(true);
                    }
                    else
                    {
                        //var masterPage = GetInitializePage(constEnumClient.Pages.Menu.ToString());
                        //masterPage.Title = nameof(masterPage);
                        //var detailPage = new NavigationPage(newPage);
                        //Application.Current.MainPage = new MasterDetailPage
                        //{
                        //    Master = masterPage,
                        //    Detail = detailPage
                        //};
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                    pushInfoOnCompletedTask?.SetResult(false);
                }
            });
        }

        void TabbedChangePush(int ActivTabIndex, Page newPage, TaskCompletionSource<bool> pushInfoOnCompletedTask = null)
        {
            Device.BeginInvokeOnMainThread(() =>
            {
                try
                {
                    var mainPage = Application.Current.MainPage as customControl.MagicTabbedPage;
                    mainPage.SelectedItem = mainPage.Children[ActivTabIndex];                    
                    pushInfoOnCompletedTask.SetResult(true);
                }
                catch
                {
                    pushInfoOnCompletedTask?.SetResult(false);
                }
            });
        }

        void TabbedPush(Page newPage, TaskCompletionSource<bool> pushInfoOnCompletedTask = null)
        {
            Device.BeginInvokeOnMainThread(async () =>
           {
               try
               {
                   if (Application.Current.MainPage is customControl.MagicTabbedPage tp)
                   {
                       try
                       {
                           var var_nav_stack = GetTopNavigation();
                           await var_nav_stack.PushAsync(newPage, true);
                           pushInfoOnCompletedTask.SetResult(true);
                       }
                       catch
                       {
                           pushInfoOnCompletedTask.SetResult(false);
                       }
                   }
                   else
                   {

                       string[] pages = new string[]{
                            constEnumClient.Pages.Main.ToString(),
                            constEnumClient.Pages.History.ToString(),
                            constEnumClient.Pages.News.ToString(),
                            constEnumClient.Pages.Yet.ToString()};
                       List<views.BasePage> basePages = GetInitializePage(pages);

                       int count = basePages.Count;
                       customControl.MagicTabbedPage tabbedPage = new customControl.MagicTabbedPage();
                       int index_active_page = 0;
                       string str_page_name = "";
                       for (int i = 0; i < count; i++)
                       {
                           str_page_name = pages[i];
                           var var_img_sourse = services.ServiceImage.Instance.GetTabbedPageImage(str_page_name);
                           views.BasePage basePage = basePages[i];
                           basePage.Title = pages[i];
                           if (basePage.str_page_name == ((views.BasePage)newPage).str_page_name)
                           {
                               newPage.Title = basePage.str_page_name;
                               var navigationPage = new NavigationPage(newPage);
                               navigationPage.Title = services.ServiceText.Instance.GetTabbedPageTitle(str_page_name);// newPage.Title;
                               navigationPage.IconImageSource = var_img_sourse;
                               navigationPage.BarBackgroundColor = Color.White;
                               tabbedPage.Children.Add(navigationPage);
                               index_active_page = i;
                           }
                           else
                           {
                               var navigationPage = new NavigationPage(basePage);
                               navigationPage.Title = services.ServiceText.Instance.GetTabbedPageTitle(str_page_name);
                               navigationPage.IconImageSource = var_img_sourse;
                               navigationPage.BarBackgroundColor = Color.White;
                               tabbedPage.Children.Add(navigationPage);
                           }                           
                           
                       }
                       tabbedPage.SelectedItem = tabbedPage.Children[index_active_page];

                       var nvPage = tabbedPage.SelectedItem as NavigationPage;
                       var pg = nvPage.CurrentPage;
                       var var_bing = pg.BindingContext as viewModels.BaseViewModel;

                       tabbedPage.action_tabbed_change = var_bing.Action_function;

                       //var var_base_view_model = ((Page)tabbedPage.SelectedItem).BindingContext as viewModels.BaseViewModel;

                       Application.Current.MainPage = tabbedPage;
                   }
               }
               catch (Exception ex)
               {
                   Console.WriteLine(ex);
                   pushInfoOnCompletedTask?.SetResult(false);
               }
           });
        }

        void CustomPush(Page newPage, TaskCompletionSource<bool> pushInfoOnCompletedTask)
        {
            // TODO: Implement your own navigation stack manipulation using popInfo
        }

        void Pop(NavigationPopInfo popInfo)
        {
            switch (popInfo.Mode)
            {
                case constEnumClient.NavigationMode.Normal:
                    NormalPop(popInfo.OnCompletedTask);
                    break;
                case constEnumClient.NavigationMode.Modal:
                    ModalPop(popInfo.OnCompletedTask);
                    break;
                case constEnumClient.NavigationMode.Custom:
                    CustomPop(popInfo.OnCompletedTask);
                    break;
                default:
                    throw new NotImplementedException();
            }
        }
        void ModalPop(TaskCompletionSource<bool> completed)
        {
            Device.BeginInvokeOnMainThread(async () =>
            {
                try
                {
                    await GetTopNavigation().PopModalAsync();
                    completed.SetResult(true);
                }
                catch
                {
                    completed.SetResult(false);
                }
            });
        }
        void CustomPop(TaskCompletionSource<bool> completed)
        {
            // TODO: Implement your own navigation stack manipulation using popInfo
        }
        void NormalPop(TaskCompletionSource<bool> completed)
        {
            Device.BeginInvokeOnMainThread(async () =>
            {
                try
                {
                    await GetTopNavigation().PopAsync();
                    completed.SetResult(true);
                }
                catch
                {
                    completed.SetResult(false);
                }
            });
        }

        #endregion

        #region Служебные функции

        /// <summary>
        /// Изменяем страницу назначения если надо, в частности пока это замена сервиса для упражнений.
        /// </summary>
        /// <param name="pushInfo"></param>
        //void ChangeGoToPage(ref NavigationPushInfo pushInfo)
        //{
        //    if (pushInfo.To == constantEnumClient.Pages.Exercise.ToString())
        //    {
        //        var myExercise = pushInfo.NavigationParams[ConstantText.strSelectedExerciseDescription] as dalDataObjects.DescriptionExercise;
        //        int id_type_exercise = myExercise.id_exercise_type;
        //        object nameToExercise = GetExercisePageByExerciseType(id_type_exercise);
        //        pushInfo.To = nameToExercise.ToString();
        //        //Console.WriteLine("ololo");
        //    }
        //}


        /// <summary>
        /// Получаем имя Page или ViewModel без соответствующего окончания
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        static string GetTypeBaseName(MemberInfo info)
        {
            if (info == null)
            {
                throw new ArgumentNullException(nameof(info));
            }

            string result = info.Name.Replace(@"Page", "").Replace(@"ViewModel", "");

            return result;
        }

        /// <summary>
        /// Формируем библиотеку Page
        /// </summary>
        /// <returns></returns>
        static Dictionary<string, Type> GetAssemblyPageTypes()
        {
            var allDefininedTypes = typeof(views.BasePage).GetTypeInfo().Assembly.DefinedTypes;
            var allPagesList = allDefininedTypes.Where(ti => ti.IsClass && !ti.IsAbstract && ti.Name.Contains(@"Page") && ti.BaseType.Name.Contains(nameof(views.BasePage)));
            Dictionary<string, Type> result = allPagesList.ToDictionary(GetTypeBaseName, ti => ti.AsType());

            return result;
        }

        /// <summary>
        /// Формируем библиотеку ViewModel
        /// </summary>
        /// <returns></returns>
        static Dictionary<string, Type> GetAssemblyViewModelTypes()
        {
            var allDefinitedTypes = typeof(viewModels.BaseViewModel).GetTypeInfo().Assembly.DefinedTypes;
            var allPageList = allDefinitedTypes.Where(ti => ti.IsClass && !ti.IsAbstract && ti.Name.Contains(@"ViewModel") && ti.BaseType.Name.Contains(@"ViewModel"));
            Dictionary<string, Type> result = allPageList.ToDictionary(GetTypeBaseName, ti => ti.AsType());

            return result;
        }


        List<views.BasePage> GetInitializePage(string[] toNames,
            Dictionary<string, object> dataToLoad = null)
        {
            List<views.BasePage> basePages = new List<views.BasePage>();

            foreach (string toName in toNames)
            {
                var var_page = GetInitializePage(toName, dataToLoad);
                basePages.Add(var_page);
            }

            return basePages;
        }
        views.BasePage GetInitializePage(string toName,
            Dictionary<string, object> dataToLoad = null
            )
        {
            var page = GetPage(toName);
            var viewModel = GetViewModel(toName);

            viewModel.str_page_name = toName;

            viewModel.SetNavigationParams(dataToLoad);
            page.BindingContext = viewModel;            

            return page;
        }

        Page GetInitializePage(NavigationPushInfo navigationPushInfo)
        {
            return GetInitializePage(
                toName: navigationPushInfo.To,
                dataToLoad: navigationPushInfo.NavigationParams);
        }

        /// <summary>
        /// Ищем страницу по имени и созда её экземпляр
        /// </summary>
        /// <param name="pageName">Имя страницы</param>
        /// <returns>Экземпляр страницы</returns>
        views.BasePage GetPage(string pageName)
        {
            if (!_pageTypes.ContainsKey(pageName)) { throw new KeyNotFoundException($@"Page for {pageName} not found"); }

            views.BasePage page;
            try
            {
                var pageType = _pageTypes[pageName];
                var pageObject = Activator.CreateInstance(pageType);
                page = pageObject as views.BasePage;
                page.str_page_name = pageName;
                //page.SetAutomationId(pageName);
            }
            catch (Exception e)
            {
                throw new TypeLoadException($@"Unable create instance for {pageName}Page", e);
            }

            //NavigationPage.SetHasNavigationBar(page, false);
            //NavigationPage.SetHasBackButton(page, false);


            return page;
        }










        /// <summary>
        /// Ищем ViewModel по имени страницы и создаю её экземпляр
        /// </summary>
        /// <param name="pageName"></param>
        /// <returns></returns>
        viewModels.BaseViewModel GetViewModel(string pageName)
        {
            if (!_viewModelTypes.ContainsKey(pageName)) 
            { 
                throw new KeyNotFoundException($@"ViewModel for {pageName} not found"); 
            }

            viewModels.BaseViewModel viewModel;

            try
            {
                viewModel = Activator.CreateInstance(_viewModelTypes[pageName]) as viewModels.BaseViewModel;

            }
            catch (Exception e)
            {
                throw new TypeLoadException($@"Unable create instance for {pageName}ViewModel", e);
            }

            return viewModel;
        }

        #endregion

        //public constantEnumClient.Pages GetExercisePageByExerciseType(int exercise_type_id)
        //{
        //    object exerciseToName = null;
        //    switch (exercise_type_id)
        //    {
        //        case (int)ConstantEnums.EnumCourseNorbekov.TypeExercises.common:
        //            exerciseToName = constantEnumClient.Pages.ExerciseCommon;
        //            break;
        //        case (int)ConstantEnums.EnumCourseNorbekov.TypeExercises.text:
        //            exerciseToName = constantEnumClient.Pages.ExerciseText;
        //            break;
        //        case (int)ConstantEnums.EnumCourseNorbekov.TypeExercises.video_master:
        //            exerciseToName = constantEnumClient.Pages.ExerciseVideoMaster;
        //            break;
        //        case (int)ConstantEnums.EnumCourseNorbekov.TypeExercises.video:
        //            exerciseToName = constantEnumClient.Pages.ExerciseVideoPlay;
        //            break;
        //        case (int)ConstantEnums.EnumCourseNorbekov.TypeExercises.check:
        //            exerciseToName = constantEnumClient.Pages.ExerciseCheck;
        //            break;
        //        case (int)ConstantEnums.EnumCourseNorbekov.TypeExercises.diary:
        //            exerciseToName = constantEnumClient.Pages.DiaryInput;
        //            break;
        //        default:
        //            throw new ArgumentException($"Exercise type : {exercise_type_id} not valide");
        //    }



        //    return (constantEnumClient.Pages)exerciseToName;
        //}
    }

    /// <summary>
    /// Данные для забабахать новую страницу
    /// </summary>
    public class NavigationPushInfo
    {
        public string From { get; set; }
        public string To { get; set; }
        //public string ToTitle { get; set; }
        public Dictionary<string, object> NavigationParams { get; set; }
        public constEnumClient.NavigationMode Mode { get; set; } = constEnumClient.NavigationMode.Normal;
        //public bool WithAnimation { get; set; } = true;
        //public bool HasNavigationBar { get; set; }
        public bool NewNavigationStack { get; set; }
        public int ActivTabIndex { get; set; } = 0;
        public TaskCompletionSource<bool> OnCompletedTask { get; set; }
    }

    /// <summary>
    /// Данные для съебать нахуй
    /// </summary>
    public class NavigationPopInfo
    {
        public constEnumClient.NavigationMode Mode { get; set; } = constEnumClient.NavigationMode.Normal;
        public TaskCompletionSource<bool> OnCompletedTask { get; set; }
        public string To { get; set; }
        //public int ActionTabId { get; set; } = 0;
        //public Dictionary<string, object> NavigationParams { get; set; }
        //public bool WithAnimation { get; set; } = true;
        //public bool Force { get; set; }
    }
}
