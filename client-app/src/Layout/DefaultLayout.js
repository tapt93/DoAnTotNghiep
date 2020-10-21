import React, { useState, useEffect } from "react";
import { Layout, Spin } from "antd";
import DefaultFooter from "./DefaultFooter";
import { AppContext } from "../context"
import routes from "../routes";
import { Route, Switch } from "react-router-dom";
import DefaultHeader from "./DefaultHeader";
import './Layout.css'


const { Header, Content, Footer, Sider } = Layout;

function DefaultLayout(props) {
  const [user, setUser] = useState(undefined);

  useEffect(() => {
    getUserInfo();
  }, [])

  async function getUserInfo() {
    //var res = await UserApi.getCurrentUserInfo("mfb.vn");
    // if (res && res.status === 200) {
    //   setUser(res.data)
    // }
    setUser({})
  }

  var screenPermistions = undefined;
  if (user !== null && user !== undefined) {
    screenPermistions = user.screenPermistions;
  }
  return (
    <>
      <AppContext.Provider value={{ userInfo: user }}>
        <Layout className="custom-layout">
          <Header className="header">
            <DefaultHeader
              useSuspense={false}
              user={user} />
          </Header>
          <Content
            style={{
              minHeight: 280
            }}
          >
            {user !== undefined ? (
              <Switch>
                {routes.map((route, index) => {
                  return (
                    <Route
                      component={route.render}
                      {...route}
                      key={"routes-" + index}
                    />
                  )

                })}
              </Switch>
            ) : <Spin style={{ marginLeft: "24px", marginTop: "20px" }} />}
          </Content>
          <Footer className="default-footer">
            {/* <DefaultFooter useSuspense={false} /> */}
          </Footer>
        </Layout>
      </AppContext.Provider>
    </>
  );
}

export default DefaultLayout;