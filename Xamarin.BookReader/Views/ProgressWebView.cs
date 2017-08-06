﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.Graphics;
using Android.Text;
using Android.Util;
using Android.Webkit;

namespace Xamarin.BookReader.Views
{
    public class ProgressWebView : LinearLayout
    {
        WebView mWebView;

        ProgressBar mProgressBar;

        private Context mContext;
        private String url;


        public ProgressWebView(Context context) : this(context, null)
        {

        }

        public ProgressWebView(Context context, IAttributeSet attrs) : this(context, attrs, 0)
        {

        }

        public ProgressWebView(Context context, IAttributeSet attrs, int defStyle)
                : base(context, attrs, defStyle)
        {

            this.mContext = context;
            initView(context);
        }

        private void initView(Context context)
        {
            View.Inflate(context, Resource.Layout.layout_web_progress, this);
            mWebView = FindViewById<WebView>(Resource.Id.web_view);
            mProgressBar = FindViewById<ProgressBar>(Resource.Id.progress_bar);
            // ButterKnife.bind(this);
        }

        public String getUrl()
        {
            return url;
        }

        public void setUrl(String url)
        {
            this.url = url;
        }

        public void loadUrl(String url)
        {
            if (TextUtils.IsEmpty(url))
            {
                url = "https://github.com/JustWayward/BookReader";
            }
            initWebview(url);
        }


        private void initWebview(String url)
        {

            mWebView.AddJavascriptInterface(this, "android");

            WebSettings webSettings = mWebView.Settings;

            webSettings.JavaScriptEnabled = (true);
            // 设置可以访问文件
            webSettings.AllowFileAccess = (true);
            // 设置可以支持缩放
            webSettings.SetSupportZoom(true);
            // 设置默认缩放方式尺寸是far
            webSettings.DefaultZoom = WebSettings.ZoomDensity.Medium;
            // 设置出现缩放工具
            webSettings.BuiltInZoomControls = (false);
            webSettings.DefaultFontSize = (16);

            mWebView.LoadUrl(url);

            // 设置WebViewClient
            //        mWebView.setWebViewClient(new WebViewClient() {
            //            // url拦截
            //            @Override
            //            public bool shouldOverrideUrlLoading(WebView view, String url) {
            //                // 使用自己的WebView组件来响应Url加载事件，而不是使用默认浏览器器加载页面
            //                view.loadUrl(url);
            //                // 相应完成返回true
            //                return true;
            //                // return super.shouldOverrideUrlLoading(view, url);
            //            }

            //            // 页面开始加载
            //            @Override
            //            public void onPageStarted(WebView view, String url, Bitmap favicon) {
            //                mProgressBar.setVisibility(View.VISIBLE);
            //                super.onPageStarted(view, url, favicon);
            //            }

            //            // 页面加载完成
            //            @Override
            //            public void onPageFinished(WebView view, String url) {
            //                mProgressBar.setVisibility(View.GONE);
            //                super.onPageFinished(view, url);
            //            }

            //            // WebView加载的所有资源url
            //            @Override
            //            public void onLoadResource(WebView view, String url) {
            //                super.onLoadResource(view, url);
            //            }

            //            @Override
            //            public void onReceivedError(WebView view, int errorCode, String description, String failingUrl) {
            ////				view.loadData(errorHtml, "text/html; charset=UTF-8", null);
            //                super.onReceivedError(view, errorCode, description, failingUrl);
            //            }

            //        });

            // 设置WebChromeClient
            //mWebView.setWebChromeClient(new WebChromeClient() {
            //    @Override
            //    // 处理javascript中的alert
            //    public bool onJsAlert(WebView view, String url, String message, JsResult result) {
            //        return super.onJsAlert(view, url, message, result);
            //    }

            //    @Override
            //    // 处理javascript中的confirm
            //    public bool onJsConfirm(WebView view, String url, String message, JsResult result) {
            //        return super.onJsConfirm(view, url, message, result);
            //    }

            //    @Override
            //    // 处理javascript中的prompt
            //    public bool onJsPrompt(WebView view, String url, String message, String defaultValue, JsPromptResult result) {
            //        return super.onJsPrompt(view, url, message, defaultValue, result);
            //    }

            //    // 设置网页加载的进度条
            //    @Override
            //    public void onProgressChanged(WebView view, int newProgress) {
            //        mProgressBar.setProgress(newProgress);
            //        super.onProgressChanged(view, newProgress);
            //    }

            //    // 设置程序的Title
            //    @Override
            //    public void onReceivedTitle(WebView view, String title) {
            //        super.onReceivedTitle(view, title);
            //    }
            //});
            //mWebView.setOnKeyListener(new OnKeyListener() {
            //    @Override
            //    public bool onKey(View v, int keyCode, KeyEvent event) {
            //        if (event.getAction() == KeyEvent.ACTION_DOWN) {
            //            if (keyCode == KeyEvent.KEYCODE_BACK && mWebView.canGoBack()) { // 表示按返回键

            //                mWebView.goBack(); // 后退

            //                // webview.goForward();//前进
            //                return true; // 已处理
            //            }
            //        }
            //        return false;
            //    }
            //});
        }

        public bool canBack()
        {
            if (mWebView.CanGoBack())
            {
                mWebView.GoBack();
                return false;
            }
            return true;
        }
    }
}