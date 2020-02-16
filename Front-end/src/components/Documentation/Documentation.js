import React from "react";

import "./Documentation.css";
import GraphQl from "../../assets/images/GraphQL_Logo.png";

function Documentation() {
  return (
    <div className="Documentation">
      <button className="expandible"> index </button>
      <div className="oculto" style={{ float: "left" }}>
        <p>1.- GraphQL</p>
        <p>2.- BD Scheme</p>
        <p>3.- ORM Django</p>
      </div>
      <p>
        Lorem ipsum dolor sit amet, consectetur adipiscing elit. Pellentesque
        finibus massa nibh, in luctus augue eleifend non. Cras consequat velit
        quis sollicitudin accumsan. Maecenas condimentum quam vel sem efficitur
        ornare. Aenean id odio in magna scelerisque interdum et sit amet enim.
        Nunc venenatis, lectus eget interdum tempus, tellus augue lacinia leo,
        et posuere nisi ligula a mauris. Sed auctor augue tellus, nec lobortis
        libero vehicula nec. Suspendisse potenti. Pellentesque vehicula
        porttitor metus, nec volutpat erat sagittis non. In sodales turpis
        neque, vitae posuere tortor sodales eget. Curabitur scelerisque
        elementum maximus. Etiam ultrices non nunc sit amet congue. Pellentesque
        habitant morbi tristique senectus et netus et malesuada fames ac turpis
        egestas.
      </p>
      <p>
        <img src={GraphQl} style={{ float: "left" }} alt=""></img>
        Aenean lacinia mattis dignissim. Suspendisse tristique lacus vitae nibh
        imperdiet, a condimentum nisi ultrices. Nulla erat odio, euismod in
        cursus ac, accumsan sed lacus. Ut eu nisl eu tellus maximus tempor vel
        eget nisi. Suspendisse quam purus, dignissim eget velit vitae, mollis
        volutpat erat. Sed elit augue, fermentum vitae mollis at, facilisis sed
        ipsum. Integer efficitur fringilla ligula, in tincidunt leo eleifend ut.
        Ut gravida elit vel magna porta, in convallis elit sollicitudin. Aliquam
        interdum, mi in tristique efficitur, tellus eros laoreet eros, a
        facilisis elit nulla eget mi.
      </p>
      <p>
        Mauris lobortis, odio id suscipit ornare, est orci sodales metus, quis
        fermentum ex augue in purus. Phasellus nec mattis neque. Maecenas
        facilisis aliquet rutrum. Aliquam ac rhoncus diam. Vivamus erat felis,
        lobortis mattis hendrerit a, convallis vitae sem. Duis massa magna,
        placerat a velit et, malesuada sodales purus. Cras nec commodo ante, in
        iaculis libero. Proin at vehicula turpis, non venenatis ex. Suspendisse
        lobortis accumsan dui, in pulvinar quam tempor nec. Curabitur ante orci,
        posuere id lectus a, pellentesque luctus eros. Nam ut semper ante, a
        sodales justo. Duis id nisl non sem ornare mattis.
      </p>
    </div>
  );
}

export default Documentation;
