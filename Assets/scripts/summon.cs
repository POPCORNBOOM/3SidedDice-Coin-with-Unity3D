using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class summon : MonoBehaviour
{
    double timer;
    public GameObject inxcount;
    public GameObject inzcount;
    public GameObject inoffsetx;
    public GameObject inoffsetz;
    public GameObject inheight;
    public GameObject inrotationx;
    public GameObject inrotationy;
    public GameObject inrotationz;
    public GameObject indeltax;
    public GameObject indeltay;
    public GameObject indeltaz;
    public GameObject indeltaheight;
    public GameObject inteststep;
    public GameObject coinlist;
    public GameObject inr;
    public GameObject indeltar;
    public GameObject inh;
    public GameObject indeltah;
    public GameObject inovertime;
    public GameObject inchecktime;

    public GameObject cstanding;
    public GameObject ctop;
    public GameObject cbottom;

    public GameObject ctotal;
    public GameObject cprocessstep;
    public GameObject cstate;
    public GameObject covertime;
    public GameObject inputboxes;
    public GameObject ctrlbutton;
    public GameObject inmass;
    public GameObject indrag;
    public GameObject inadrag;
    public GameObject indeltamass;
    public GameObject indeltadrag;
    public GameObject indeltaadrag;
    public GameObject handle;
    public GameObject invx;
    public GameObject invy;
    public GameObject invz;
    public GameObject indvx;
    public GameObject indvy;
    public GameObject indvz;
    public GameObject inavx;
    public GameObject inavy;
    public GameObject inavz;
    public GameObject indavx;
    public GameObject indavy;
    public GameObject indavz;
    //public GameObject ;

    bool istesting = false;
    public GameObject obj;
    int xcount;
    int zcount;
    float r;
    float deltar;
    float h;
    float deltah;
    float offsetx;
    float offsetz;

    float height;
    float deltaheight;

    float rotationx;
    float rotationy;
    float rotationz;
    float deltax;
    float deltay;
    float deltaz;


    int summonindex;
    int teststep;
    int processstep;
    public float summontime;

    float mass;
    float drag;
    float adrag;
    float deltamass;
    float deltadrag;
    float deltaadrag;
    string outdata = "";
    string oncedata = "";

    float vx;
    float vy;
    float vz;
    float dvx;
    float dvy;
    float dvz;

    float avx;
    float avy;
    float avz;
    float davx;
    float davy;
    float davz;
    //List<GameObject> mylist;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (timer > 0)
            timer -= Time.deltaTime;
        covertime.GetComponent<Text>().text = timer.ToString();
    }

    public void timechange()
    {
        Time.timeScale = handle.GetComponent<Slider>().value;
    }
    public void summoninstance()
    {
        if (istesting)
        {
            /*string filename = "D:\\TestTxt" + DateTime.Now + ".txt";
            CancelInvoke("repeating");
            //inputboxes.SetActive(true);
            if (!File.Exists(filename))
            {
                FileStream fs1 = new FileStream(filename, FileMode.Create, FileAccess.Write);//创建写入文件
                StreamWriter sw = new StreamWriter(fs1);
                sw.WriteLine(outdata);//开始写入值
                sw.Close();
                fs1.Close();
            }
            else
                File.Delete(filename);*/
            processstep = teststep;
            ctrlbutton.GetComponent<Text>().text = "start";
            istesting = false;

        }
        else
        {
            mass = inmass.GetComponent<Text>().text == "" ? 1F : Convert.ToSingle(inmass.GetComponent<Text>().text);
            drag = inadrag.GetComponent<Text>().text == "" ? 0F : Convert.ToSingle(indrag.GetComponent<Text>().text);
            adrag = inadrag.GetComponent<Text>().text == "" ? 0.05F : Convert.ToSingle(inadrag.GetComponent<Text>().text);
            deltamass = indeltamass.GetComponent<Text>().text == "" ? 0F : Convert.ToSingle(indeltamass.GetComponent<Text>().text);
            deltadrag = indeltadrag.GetComponent<Text>().text == "" ? 0F : Convert.ToSingle(indeltadrag.GetComponent<Text>().text);
            deltaadrag = indeltaadrag.GetComponent<Text>().text == "" ? 0F : Convert.ToSingle(indeltaadrag.GetComponent<Text>().text);

            xcount = inxcount.GetComponent<Text>().text == "" ? 10 : Convert.ToInt32(inxcount.GetComponent<Text>().text);
            zcount = inzcount.GetComponent<Text>().text == "" ? 10 : Convert.ToInt32(inzcount.GetComponent<Text>().text);
            offsetx = inoffsetx.GetComponent<Text>().text == "" ? 20F : Convert.ToSingle(inoffsetx.GetComponent<Text>().text);
            offsetz = inoffsetz.GetComponent<Text>().text == "" ? 20F : Convert.ToSingle(inoffsetz.GetComponent<Text>().text);

            height = inheight.GetComponent<Text>().text == "" ? 0.5F : Convert.ToSingle(inheight.GetComponent<Text>().text);
            deltaheight = indeltaheight.GetComponent<Text>().text == "" ? 0F : Convert.ToSingle(indeltaheight.GetComponent<Text>().text);

            rotationx = inrotationx.GetComponent<Text>().text == "" ? 0F : Convert.ToSingle(inrotationx.GetComponent<Text>().text);
            rotationy = inrotationy.GetComponent<Text>().text == "" ? 0F : Convert.ToSingle(inrotationy.GetComponent<Text>().text);
            rotationz = inrotationz.GetComponent<Text>().text == "" ? 0F : Convert.ToSingle(inrotationz.GetComponent<Text>().text);
            if (indeltax.GetComponent<Text>().text == "")
                deltax = 0F;
            else if (indeltax.GetComponent<Text>().text == "R")
                deltax = float.Epsilon;
            else if (indeltax.GetComponent<Text>().text == "Re")
                deltax = float.MaxValue;
            else
                deltax = Convert.ToSingle(indeltax.GetComponent<Text>().text);

            if (indeltay.GetComponent<Text>().text == "")
                deltay = 0F;
            else if (indeltay.GetComponent<Text>().text == "R")
                deltay = float.Epsilon;
            else if (indeltay.GetComponent<Text>().text == "Re")
                deltay = float.MaxValue;
            else
                deltay = Convert.ToSingle(indeltay.GetComponent<Text>().text);

            if (indeltaz.GetComponent<Text>().text == "")
                deltaz = 0F;
            else if (indeltaz.GetComponent<Text>().text == "R")
                deltaz = float.Epsilon;
            else if (indeltaz.GetComponent<Text>().text == "Re")
                deltaz = float.MaxValue;
            else
                deltaz = Convert.ToSingle(indeltaz.GetComponent<Text>().text);


            vx = invx.GetComponent<Text>().text == "" ? 0F : Convert.ToSingle(invx.GetComponent<Text>().text);
            vy = invy.GetComponent<Text>().text == "" ? 0F : Convert.ToSingle(invy.GetComponent<Text>().text);
            vz = invz.GetComponent<Text>().text == "" ? 0F : Convert.ToSingle(invz.GetComponent<Text>().text);
            dvx = indvx.GetComponent<Text>().text == "" ? 0F : Convert.ToSingle(indvx.GetComponent<Text>().text);
            dvy = indvy.GetComponent<Text>().text == "" ? 0F : Convert.ToSingle(indvy.GetComponent<Text>().text);
            dvz = indvz.GetComponent<Text>().text == "" ? 0F : Convert.ToSingle(indvz.GetComponent<Text>().text);

            avx = inavx.GetComponent<Text>().text == "" ? 0F : Convert.ToSingle(inavx.GetComponent<Text>().text);
            avy = inavy.GetComponent<Text>().text == "" ? 0F : Convert.ToSingle(inavy.GetComponent<Text>().text);
            avz = inavz.GetComponent<Text>().text == "" ? 0F : Convert.ToSingle(inavz.GetComponent<Text>().text);
            davx = indavx.GetComponent<Text>().text == "" ? 0F : Convert.ToSingle(indavx.GetComponent<Text>().text);
            davy = indavy.GetComponent<Text>().text == "" ? 0F : Convert.ToSingle(indavy.GetComponent<Text>().text);
            davz = indavz.GetComponent<Text>().text == "" ? 0F : Convert.ToSingle(indavz.GetComponent<Text>().text);


            teststep = inteststep.GetComponent<Text>().text == "" ? 100 : Convert.ToInt32(inteststep.GetComponent<Text>().text);

            r = inr.GetComponent<Text>().text == "" ? 0.1F : Convert.ToSingle(inr.GetComponent<Text>().text);
            deltar = indeltar.GetComponent<Text>().text == "" ? 0F : Convert.ToSingle(indeltar.GetComponent<Text>().text);
            h = inh.GetComponent<Text>().text == "" ? 0.1F : Convert.ToSingle(inh.GetComponent<Text>().text);
            deltah = indeltah.GetComponent<Text>().text == "" ? 0F : Convert.ToSingle(indeltah.GetComponent<Text>().text);

            summontime = inovertime.GetComponent<Text>().text == "" ? 10F : Convert.ToSingle(inovertime.GetComponent<Text>().text);
            ctotal.GetComponent<Text>().text = (xcount * zcount).ToString();

            processstep = 0;
            //inputboxes.SetActive(false);
            ctrlbutton.GetComponent<Text>().text = "stop";
            outdata = "Standing,top,bottom,Total,Height,RotationX,RotationY,RotationZ,ScaleR,ScaleH,Mass,Drag,AngularDrag,VelocityXYZ,AngularVelocity\n";
            oncedata = "0,0,0,0,0,0,0,0,0,(0|0|0),(0|0|0)";
            InvokeRepeating("repeating", 0, summontime);
            istesting = true;

        }

    }
    public void repeating()
    {
        outdata += cstanding.GetComponent<Text>().text + "," + ctop.GetComponent<Text>().text + "," + cbottom.GetComponent<Text>().text + "," + zcount * xcount + "," + oncedata +"\n";
        timer = summontime;
        //GameObject.Find("Canvas/_Standing/c_standing").GetComponent<Text>().text = 0.ToString();
        cstanding.GetComponent<Text>().text = 0.ToString();
        ctop.GetComponent<Text>().text = 0.ToString();
        cbottom.GetComponent<Text>().text = 0.ToString();
        cprocessstep.GetComponent<Text>().text = processstep.ToString();
        Destroy(GameObject.FindGameObjectWithTag("lastList"));
        GameObject newlist = (GameObject)Instantiate(coinlist);
        newlist.tag = "lastList";

        /*
        if (mylist != null)
        {
            foreach (var item in mylist)
            {
                if (item != null)
                    Destroy(item, 0);
            }

        }*/

        float newheight = height + deltaheight * processstep;
        float rx = GetRandom(0F, 360F);
        float ry = GetRandom(0F, 360F);
        float rz = GetRandom(0F, 360F);
        rx = deltax == float.Epsilon ? rx : (rotationx + deltax * processstep) % 360;
        ry = deltay == float.Epsilon ? ry : (rotationy + deltay * processstep) % 360;
        rz = deltaz == float.Epsilon ? rz : (rotationz + deltaz * processstep) % 360;
        Vector3 myscale = new Vector3((r + deltar * processstep) * 2, (h + deltah * processstep) * 0.5f, (r + deltar * processstep) * 2);
        Vector3 myvelocity = new Vector3((vx+dvx*processstep),(vy + dvy * processstep), (vz + dvz * processstep));
        Vector3 myavelocity = new Vector3((avx + davx * processstep), (avy + davy * processstep), (avz + davz * processstep));
        //cstate.GetComponent<Text>().text = "h:" + newheight + "--rot(x,y,z):(" + (rotationx + deltax * processstep) + "," + (rotationy + deltay * processstep) + "," + (rotationz + deltaz * processstep) + ")--scale(R,H):(" + (r + deltar * processstep) + "," + (h + deltah * processstep) + ")";
        oncedata = newheight + "," + (deltax == float.Epsilon ? rx : (rotationx + deltax * processstep) % 360) +"," + (deltay == float.Epsilon ? ry : (rotationy + deltay * processstep) % 360) + "," + (deltaz == float.Epsilon ? rz : (rotationz + deltaz * processstep) % 360) +"," + (r + deltar * processstep) + "," + (h + deltah * processstep) + "," + (mass + deltamass * processstep) + "," + (drag + deltadrag * processstep) + "," + (adrag + deltaadrag * processstep) + "," + myvelocity.ToString().Replace(",", " |") + "," + myavelocity.ToString().Replace(",", " |");
        cstate.GetComponent<Text>().text = "Height|RotationX/Y/Z|ScaleR/H|Mass|Drag|AngularDrag|VelocityX/Y/Z|AngularVelocityX/Y/Z\n" + oncedata;
        //Debug.Log("Height|RotationX/Y/Z|ScaleR/H|Mass|Drag|AngularDrag|VelocityX/Y/Z|AngularVelocityX/Y/Z\n" + oncedata);
        //Debug.Log("rx" + rotationx + "dx" + deltax + "ps" + processstep);
        for (int i = 0; i < xcount; i++)
        {
            for (int j = 0; j < zcount; j++)
            {
                Quaternion newquaternion = Quaternion.Euler(new Vector3(
                    deltax == float.MaxValue ? GetRandom(0F, 360F) : rx,
                    deltay == float.MaxValue ? GetRandom(0F, 360F) : ry,
                    deltaz == float.MaxValue ? GetRandom(0F, 360F) : rz
                    ));
                cstanding.GetComponent<Text>().text = 0.ToString();
                ctop.GetComponent<Text>().text = 0.ToString();
                cbottom.GetComponent<Text>().text = 0.ToString();
                GameObject instance = (GameObject)Instantiate(obj, new Vector3(i * offsetx, newheight, j * offsetz), newquaternion);
                instance.transform.localScale = myscale;
                instance.transform.parent = newlist.transform;
                instance.GetComponent<Rigidbody>().mass = mass+deltamass*processstep;
                instance.GetComponent<Rigidbody>().drag = drag + deltadrag * processstep;
                instance.GetComponent<Rigidbody>().angularDrag = adrag + deltaadrag * processstep;
                instance.GetComponent<Rigidbody>().velocity = myvelocity;
                instance.GetComponent<Rigidbody>().angularVelocity = myavelocity;//myavelocity;
                //mylist.Add(instance);
            }
        }
        processstep++;
        if (processstep >= teststep+1)
        {
            string filename = DateTime.Now + ".csv";
            filename = filename.Replace("/", string.Empty).Replace(":", string.Empty).Replace(" ", string.Empty);
            filename = GameObject.Find("Canvas/t_dir").GetComponent<Text>().text + "\\Test" + filename;
            if (File.Exists(filename))
            {
                File.Delete(filename);
            }
            FileStream fs1 = new FileStream(filename, FileMode.Create, FileAccess.Write);//创建写入文件
            StreamWriter sw = new StreamWriter(fs1);
            sw.WriteLine(outdata);//开始写入值
            sw.Close();
            fs1.Close();
            Destroy(GameObject.FindGameObjectWithTag("lastList"));
            timer = 0;
            ctrlbutton.GetComponent<Text>().text = "start";
            istesting = false;
            CancelInvoke("repeating");


        }



    }

    public float GetRandom(float a,float b)
    {
        float random = UnityEngine.Random.Range(a, b);
        //Debug.Log(random);
        return random;
    }

    public void SetDefault()
    {
        invx.GetComponent<Text>().text = "0";
        //Debug.Log("shit");
        invy.GetComponent<Text>().text = "0";
        invz.GetComponent<Text>().text = "0";
        indvx.GetComponent<Text>().text = "0";
        indvy.GetComponent<Text>().text = "0";
        indvz.GetComponent<Text>().text = "0";
        inavx.GetComponent<Text>().text = "0";
        inavy.GetComponent<Text>().text = "0";
        inavz.GetComponent<Text>().text = "0";
        indavx.GetComponent<Text>().text = "0";
        indavy.GetComponent<Text>().text = "0";
        indavz.GetComponent<Text>().text = "0";
        inteststep.GetComponent<Text>().text = "50";
        inr.GetComponent<Text>().text = "0.1";
        indeltar.GetComponent<Text>().text = "0";
        inh.GetComponent<Text>().text = "0.1";
        indeltah.GetComponent<Text>().text = "0";
        inovertime.GetComponent<Text>().text = "3";
        inmass.GetComponent<Text>().text = "1";
        indrag.GetComponent<Text>().text = "0";
        inadrag.GetComponent<Text>().text = "0.05";
        indeltamass.GetComponent<Text>().text = "0";
        indeltadrag.GetComponent<Text>().text = "0";
        indeltaadrag.GetComponent<Text>().text = "0";
        inxcount.GetComponent<Text>().text = "10";
        inzcount.GetComponent<Text>().text = "10";
        inoffsetx.GetComponent<Text>().text = "20";
        inoffsetz.GetComponent<Text>().text = "20";
        inheight.GetComponent<Text>().text = "5";
        indeltaheight.GetComponent<Text>().text = "1";
        inrotationx.GetComponent<Text>().text = "0";
        inrotationy.GetComponent<Text>().text = "0";
        inrotationz.GetComponent<Text>().text = "0";
        indeltax.GetComponent<Text>().text = "0";
        indeltay.GetComponent<Text>().text = "0";
        indeltaz.GetComponent<Text>().text = "0";
    }
}
