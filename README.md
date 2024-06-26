# ブロックスのコンピュータについて知見を深めるためのプログラム
本プログラムはブロックスの対戦コンピュータ(以降AIと呼称)がどのようなアルゴリズムでブロックを置いていくと、強い対戦相手となるかを実験するために作成しているものである。

## 操作方法
「Auto」ボタン：自動的で対戦を進行

「Next」ボタン：１手進ませることができる。

「RESET」ボタン：対戦状況を初期化

## 現在のアルゴリズム
AIは手持ちのブロックをすべて **評価値** を計算し高い順に盤面におけるものから置いていく。
### 評価値について
評価値は以下の３つからなる

角の数：ブロックスは角につなげていくゲームであるため角の数が勝敗に影響する。

面積：ブロックのタイル数を表したものである。

幅：ブロックの縦と横の幅からなる対角線上の長さを示したものである。

### それぞれの評価値をどう扱うか

それぞれのAIには上記の「角の数」「面積」「幅」のどの項目をどの程度重要視するかというパラメータを持っている。

最終的な評価値 = 角の数 * パラメータ1 + 面積 * パラメータ2 + 幅 * パラメータ3

敗北したAIは勝利したAIを参考に自分の値を変更させる。また、より強力なAIを見つけるために勝利したAIにそのまま近づけるのではなく、ある程度の乱数を用いて未知の強いAIのパラメータを見つけることを目指している。