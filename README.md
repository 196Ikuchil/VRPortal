# VRPortal

## Description
Shader を使用し、VR 空間での空間移動を表現する
元ネタはこちらの方-> https://github.com/edom18/VR-PortalSample

## Features
Unity ネイティブの VR ライブラリを使用しているため、HMD の種類にとらわれず起動可能( Oculus Rift のみ確認済み)

## Requirement
・Oculus Rift (2017/3月末購入)
・Unity 5.6.0f3 Personal
・Windows10 64bit Home (Oculusを走らせることが可能なもの)

## Usage
移動(move)  W,A,S,D
Portalを生成(Create Portal) G


##Unimplemented
・ポータルの裏側はシースルーになっているが、移動判定は消されていないため、裏側に触れることでも別空間に移動してしまう。
・別空間に設置したポータルは、今いる空間にあるポータルから覗いても見ることができない。バグ(処理的な問題)があり、アプリが強制終了してしまうので、
見えないようにした。
